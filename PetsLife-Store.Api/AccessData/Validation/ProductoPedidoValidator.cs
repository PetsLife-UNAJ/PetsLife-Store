using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Domain.Entities;

namespace AccessData.Validation
{
    public class ProductoPedidoValidator : AbstractValidator<ProductoPedido>
    {
        public ProductoPedidoValidator()
        {
            RuleFor(e => e.Cantidad).NotNull().WithMessage("La cantidad del producto es requerida.");
            RuleFor(e => e.Producto).NotNull().WithMessage("El producto es requerido.");
        }

    }
}
