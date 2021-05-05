using Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Services
{
    public interface ICarritoService
    {
        public ResponseGetCarritoById GetCarritoById(int id);
        public int CalcularPrecioTotal(ResponseGetProductoById producto , ResponseGetCarritoById carrito);
        public GenericsCreatedResponseDto AddProductoPedido(int idproducto, int idcarrito);
        public void RemoveProductoPedidoFromCarrito(int idProductoPedido);
    }
}
