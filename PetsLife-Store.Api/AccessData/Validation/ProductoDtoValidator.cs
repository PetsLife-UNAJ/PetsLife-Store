using Domain.DTOs;
using FluentValidation;

namespace AccessData.Validation
{
    public class ProductoDtoValidator : AbstractValidator<AddProductoDTO>
    {
        public ProductoDtoValidator()
        {
            RuleFor(e => e.Categoria).MaximumLength(255).NotEmpty().WithMessage("La categoria del producto es requerida.");
            RuleFor(e => e.Nombre).MaximumLength(255).NotEmpty().WithMessage("El nombre del producto es requerido.");
            RuleFor(e => e.Imagen).MaximumLength(255).NotEmpty().WithMessage("La imagen es requerida");
            RuleFor(e => e.Precio).LessThan(int.MaxValue).GreaterThan(-1).WithMessage($"El precio del producto debe ser mayor o igual que cero y menor que {int.MaxValue}");
            RuleFor(e => e.CantidadStock).LessThan(int.MaxValue).GreaterThan(-1).WithMessage($"El stock debe ser mayor o igual que cero y menor que {int.MaxValue}");
        }

    }
}
