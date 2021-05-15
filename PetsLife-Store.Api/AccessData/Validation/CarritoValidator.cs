using Domain.Entities;
using FluentValidation;

namespace AccessData.Validation
{
    public class CarritoValidator : AbstractValidator<Carrito>
    {
        public CarritoValidator()
        {
            RuleFor(e => e.Comprador).NotNull().WithMessage("Falto ingresar usuario del carrito.");
        }
    }
}
