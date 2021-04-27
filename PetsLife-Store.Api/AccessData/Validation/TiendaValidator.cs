using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Domain.Entities;

namespace AccessData.Validation
{
    public class TiendaValidator : AbstractValidator<Tienda>
    {
        public TiendaValidator()
        {
            // No necesaria porque la tienda no tiene que poder editarse nunca.
        }
    }
}
