using Domain.DTOs;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Queries
{
    public interface ICarritoQuery
    {
        public ResponseGetCarritoById GetCarritoById(int id);
        public ProductoPedido GetProductoPedidoById(int idProductoPedido);
    }
}
