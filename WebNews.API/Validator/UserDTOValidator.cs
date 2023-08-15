using FluentValidation;
using WebNews.API.Models;

namespace WebNews.API.Validator;

public class UserDTOValidator:AbstractValidator<UserDTO>
{
    public UserDTOValidator()
    {
        RuleFor(u => u.Email)
           .Cascade(CascadeMode.Stop)
           .NotEmpty().WithMessage("Email é obrigatório")
           .Matches(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$").WithMessage("Informe um email no formato email@email.com");

        RuleFor(u => u.Password)
            .NotEmpty().WithMessage("Password é obrigatório");

        RuleFor(u => u.ConfirmPassaword)
            .NotEmpty().WithMessage("ConfirmPassaword é obrigatório");
    }
}
