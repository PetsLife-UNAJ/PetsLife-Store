using Domain.DTOs;
using Domain.Entities;
using FluentValidation;

namespace AccessData.Validation
{
    public class ProductoPedidoDtoValidator : AbstractValidator<AddProductoPedidoDTO>
    {
        public ProductoPedidoDtoValidator()
        {
            RuleFor(e => e.ProductoId)
                .GreaterThan(0).WithMessage("ProductoId debe ser mayor que cero.")
                .NotEmpty().WithMessage("ProductoId no puede estar vacio.");
                
            RuleFor(e => e.CarritoId)
                .GreaterThan(0).WithMessage("CarritoId debe ser mayor que cero.")
                .NotEmpty().WithMessage("CarritoId no puede estar vacio");
        }

    }
}
