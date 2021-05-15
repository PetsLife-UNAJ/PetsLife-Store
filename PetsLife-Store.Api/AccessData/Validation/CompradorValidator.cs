using Domain.Entities;
using FluentValidation;

namespace AccessData.Validation
{
    public class CompradorValidator : AbstractValidator<Comprador>
    {
        public CompradorValidator()
        {
            RuleFor(e => e.Nombre)
                .MaximumLength(16).WithMessage("Maximo caracteres para nombre excedido, el maximo es 16.")
                .NotEmpty().WithMessage("El nombre no puede estar vacio.");

            RuleFor(e => e.Email)
                .MaximumLength(255).NotEmpty().WithMessage("El mail no puede estar vacio y debe tener un maximo de 255 caracteres");//.EmailAddress()
           
            RuleFor(e => e.CompradorId).NotEmpty();
        }
    }
}
