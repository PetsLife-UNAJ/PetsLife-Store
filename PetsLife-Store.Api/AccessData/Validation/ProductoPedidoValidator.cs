using Domain.Entities;
using FluentValidation;

namespace AccessData.Validation
{
    public class ProductoPedidoValidator : AbstractValidator<ProductoPedido>
    {
        public ProductoPedidoValidator()
        {
            RuleFor(e => e.Cantidad)
                .GreaterThan(-1).WithMessage($"La cantidad debe estar entre cero y {int.MaxValue}")
                .NotEmpty().WithMessage("La cantidad del producto es requerida.");

            RuleFor(e => e.Producto).NotEmpty().WithMessage("El producto es requerido.");
            RuleFor(e => e.ProductoId).NotEmpty();
            RuleFor(e => e.CarritoId).NotEmpty();
        }

    }
}
