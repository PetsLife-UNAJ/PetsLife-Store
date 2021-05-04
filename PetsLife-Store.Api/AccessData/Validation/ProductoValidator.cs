using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Domain.Entities;

namespace AccessData.Validation
{
    public class ProductoValidator : AbstractValidator<Producto>
    {
        public ProductoValidator()
        {
            RuleFor(e => e.Categoria).NotNull().NotEmpty().WithMessage("La categoria del producto es requerida.");
            RuleFor(e => e.Nombre).NotNull().NotEmpty().WithMessage("El nombre del producto es requerido.");
            RuleFor(e => e.Imagen).NotNull().NotEmpty().WithMessage("La imagen es requerida");
            RuleFor(e => e.Nombre).MaximumLength(100).WithMessage("Cantidad de caracteres del nombre excedido");
            RuleFor(e => e.Precio).GreaterThan(-1).WithMessage("El precio del producto debe ser mayor o igual que cero");
            RuleFor(e => e.CantidadStock).GreaterThan(-1).WithMessage("El stock debe ser mayor o igual que cero");
        }

    }
}
