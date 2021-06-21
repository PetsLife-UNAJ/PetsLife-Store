using Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Services
{
    public interface ICategoriaService
    {
        ResponseCategoriaDto CreateCategoria(AddCategoriaDto categoriaDto);
        bool DeleteCategoria(int id);
        List<GetCategoriaDto> GetCategorias();
    }
}
