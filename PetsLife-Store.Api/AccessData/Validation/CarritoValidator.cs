using Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
