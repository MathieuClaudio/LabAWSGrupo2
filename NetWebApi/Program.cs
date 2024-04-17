using Repository;
using Microsoft.EntityFrameworkCore;
using FluentValidation.AspNetCore;
using FluentValidation;
using Repository.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Model.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Model.Interfaces;
using Microsoft.OpenApi.Models;
using System;
using System.IdentityModel.Tokens.Jwt;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

// Add services to the container.

//--------------SqlServer------------------------
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
        b => b.MigrationsAssembly("Repository")));

//--------------Inyecciones----------------------------------------
builder.Services.AddScoped<IClubRepository, ClubRepository>();
builder.Services.AddScoped<IPlayerRepository, PlayerRepository>();
builder.Services.AddScoped<IStadiumRepository, StadiumRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>(
    x => new UnitOfWork(
        x.GetRequiredService<ApplicationDbContext>(),
        x.GetRequiredService<IPlayerRepository>(),
        x.GetRequiredService<IClubRepository>(),
        x.GetRequiredService<IStadiumRepository>(),
        x.GetRequiredService<IUserRepository>()
    ));
//----------------------------------------------------------------

//--------------FluentValidation----------------------------------
builder.Services.AddValidatorsFromAssemblyContaining<Program>();
builder.Services.AddFluentValidationAutoValidation();
//----------------------------------------------------------------



//---------------------------------------JWT Swagger-----------------------------
//builder.Services.AddSwaggerGen();

builder.Services.AddSwaggerGen(option =>
{
    option.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "JWT", Version = "v1" });
    option.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    {
        In = Microsoft.OpenApi.Models.ParameterLocation.Header,
        Description = "Ingrese Token",
        Name = "Authorization",
        Type = Microsoft.OpenApi.Models.SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    option.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement()
        {
        {new OpenApiSecurityScheme
        {
             Reference = new OpenApiReference
             { Type = ReferenceType.SecurityScheme,
              Id = "Bearer"
             }
        },
        new string[]{}

        }
    });
});
//--------------------------------------------------------------------------------

//-----------------------------JWT---------------------------------------------
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidAudience = builder.Configuration["Jwt:Audience"],
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))

    };
});
//----------------------------------------------------------------

var app = builder.Build();


app.UseAuthentication(); // JWT
app.UseAuthorization();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.Run();
