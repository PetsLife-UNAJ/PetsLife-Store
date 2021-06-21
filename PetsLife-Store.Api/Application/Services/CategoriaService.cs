using AccessData.Commands.Repository;
using Domain.DTOs;
using Domain.Entities;
using Domain.Interfaces.Queries;
using Domain.Interfaces.Services;
using System.Collections.Generic;

namespace Application.Services
{
    public class CategoriaService : ICategoriaService
    {
        private readonly IGenericsRepository _repository;
        private readonly ICategoriaQuery _query;

        public CategoriaService(IGenericsRepository repository, ICategoriaQuery query)
        {
            _repository = repository;
            _query = query;
        }
        public ResponseCategoriaDto CreateCategoria(AddCategoriaDto categoriaDto)
        {
            var entity = new Categoria
            {
                Descripcion = categoriaDto.Descripcion
            };
            _repository.Add<Categoria>(entity);
            return new ResponseCategoriaDto
            {
                CategoriaId = entity.CategoriaId.ToString(),
                Descripcion = entity.Descripcion
            };
        }

        public bool DeleteCategoria(int id)
        {
            Categoria categoria = _repository.Exists<Categoria>(id);
            if (categoria == null)
            {
                return false;
            }
            else
            {
                _repository.Delete<Categoria>(categoria);
                return true;
            }
        }

        public List<GetCategoriaDto> GetCategorias()
        {
            return _query.GetAllCategorias();
        }
    }
}
