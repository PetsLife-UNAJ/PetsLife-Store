using Domain.DTOs;
using Domain.Entities;
using Domain.Interfaces.Queries;
using SqlKata.Compilers;
using SqlKata.Execution;
using System.Data;
using System.Linq;

namespace AccessData.Queries
{
    public class CarritoQuery : ICarritoQuery
    {
        private readonly IDbConnection connection;
        private readonly Compiler sqlKatacompiler;
        private readonly IProductoQuery _producto_query;


        public CarritoQuery(IDbConnection connection, Compiler sqlKatacompiler, IProductoQuery producto_query)
        {
            this.connection = connection;
            this.sqlKatacompiler = sqlKatacompiler;
            _producto_query = producto_query;
        }

        public CarritoDTO GetCarritoById(int carritoId)
        {
            var db = new QueryFactory(connection, sqlKatacompiler);
            CarritoDTO carr = db.Query("Carritos").Where("CarritoId", carritoId).Get<CarritoDTO>().FirstOrDefault();
            
            return carr;
        }
    }
}
