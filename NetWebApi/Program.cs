using Repository;
using Microsoft.EntityFrameworkCore;
using FluentValidation.AspNetCore;
using FluentValidation;
using Repository.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Model.Entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//--------------SqlServer------------------------
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
        b => b.MigrationsAssembly("Repository")));

//--------------Inyecciones------------------------
builder.Services.AddScoped<IClubRepository, ClubRepository>();
builder.Services.AddScoped<IPlayerRepository, PlayerRepository>();
builder.Services.AddScoped<IStadiumRepository, StadiumRepository>();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>(
    x => new UnitOfWork(
        x.GetRequiredService<ApplicationDbContext>(),
        x.GetRequiredService<IPlayerRepository>(),
        x.GetRequiredService<IClubRepository>(),
        x.GetRequiredService<IStadiumRepository>()
    ));

//--------------FluentValidation------------------------
builder.Services.AddValidatorsFromAssemblyContaining<Program>();
builder.Services.AddFluentValidationAutoValidation();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
