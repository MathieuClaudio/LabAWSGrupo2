using FluentValidation;

namespace NetWebApi.DTOs
{
    public class FluentValidationDtos : AbstractValidator<ClubPostDto>
    {

        public FluentValidationDtos()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("El nombre no puede estar vacio");
            //RuleFor(x => x.Name).Length(3, 5).WithMessage("El nombre debe contener entre 3 y 5 caracteres");
        }


    }
}
