using Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessData.Validation
{
    public class CompradorValidator : AbstractValidator<Comprador>
    {
        public CompradorValidator()
        {
            RuleFor(e => e.Nombre).MaximumLength(16).WithMessage("Maximo caracteres para nombre excedido, el maximo es 16.");
        }
    }
}
