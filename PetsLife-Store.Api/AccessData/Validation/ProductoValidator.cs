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
            RuleFor(e => e.Categoria).NotNull().WithMessage("La categoria del producto es requerida.");
            RuleFor(e => e.Nombre).NotNull().WithMessage("El nombre del producto es requerido.");
            RuleFor(e => e.Nombre).MaximumLength(100).WithMessage("Cantidad de caracteres del nombre excedido");
            RuleFor(e => e.Precio).GreaterThan(-1).WithMessage("El precio del producto debe ser mayor o igual que cero");
        }

    }
}
