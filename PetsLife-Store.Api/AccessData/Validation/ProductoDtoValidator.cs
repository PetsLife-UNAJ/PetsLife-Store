using AccessData.Commands.Repository;
using Domain.DTOs;
using Domain.Entities;
using FluentValidation;

namespace AccessData.Validation
{
    public class ProductoDtoValidator : AbstractValidator<AddProductoDTO>
    {
        IGenericsRepository genericsRepository;
        public ProductoDtoValidator(IGenericsRepository genericsRepository)
        {
            this.genericsRepository = genericsRepository;
            
            RuleFor(e => e.Nombre).MaximumLength(255).NotEmpty().WithMessage("El nombre del producto es requerido.");
            RuleFor(e => e.Imagen).MaximumLength(255).NotEmpty().WithMessage("La imagen es requerida");
            RuleFor(e => e.Precio).LessThan(int.MaxValue).GreaterThan(-1).WithMessage($"El precio del producto debe ser mayor o igual que cero y menor que {int.MaxValue}");
            RuleFor(e => e.CantidadStock).LessThan(int.MaxValue).GreaterThan(-1).WithMessage($"El stock debe ser mayor o igual que cero y menor que {int.MaxValue}");
            RuleFor(e => e.Rating).GreaterThan(-1).LessThan(11);
            RuleFor(e => e.Descripcion).MaximumLength(1024).WithMessage("Tamaño maximo de caracteres excedido (1024)");

            RuleFor(e => e.Categoria).Must(ExisteCategoria).WithMessage("La categoria no es valida");
        }

        private bool ExisteCategoria(int idCategoria)
        {
            Categoria categoria = genericsRepository.Exists<Categoria>(idCategoria);
            if (categoria == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

    }
}
