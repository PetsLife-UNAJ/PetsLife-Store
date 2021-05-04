using AccessData.Commands.Repository;
using Domain.DTOs;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Interfaces.Queries;
using Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{   
    public class CarritoService  : ICarritoService
    {
        private readonly IGenericsRepository _repository;
        private readonly ICarritoQuery _query;

        public CarritoService(IGenericsRepository repository, ICarritoQuery query)
        {
            _repository = repository;
            _query = query;
        }

        // cambiar, el precio total se obtiene con la lista de todos los productos del carrito
        public int CalcularPrecioTotal(List<ResponseGetProductoById> productos)
        {
            int total = 0;
            List<ResponseGetProductoById> aux = productos;
            foreach (var item in aux)
            {
                total += item.Precio;
            }
            return total;
        }

        public void AddProductoPedido(int idproducto, int idcarrito)
        {
            ProductoPedido productoPedido = new()
            {
                ProductoId = idproducto,
                CarritoId = idcarrito,
                Cantidad = 1
            };
            _repository.Add(productoPedido);
        }

        public CarritoDTO GetCarritoById(int idCarrito)
        {
            return _query.GetCarritoById(idCarrito);
        }
    }
}
