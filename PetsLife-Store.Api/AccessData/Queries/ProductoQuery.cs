﻿using Domain.DTOs;
using Domain.Interfaces.Queries;
using SqlKata.Compilers;
using SqlKata.Execution;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessData.Queries
{
    public class ProductoQuery:IProductoQuery
    {
        private readonly IDbConnection connection;
        private readonly Compiler sqlKatacompiler;


        public ProductoQuery(IDbConnection connection, Compiler sqlKatacompiler)
        {
            this.connection = connection;
            this.sqlKatacompiler = sqlKatacompiler;
        }

        public List<ProductoDto> GetProductoById(int id)
        {
            var db = new QueryFactory(connection, sqlKatacompiler);
            var producto = db.Query("Productos").Select(
                "Nombre", "Categoria", "Imagen"
                , "CantidadStock","Precio"
                ).Where("ProductoId", "=", id);
            var query = producto.Get<ProductoDto>();
            return query.ToList();
        }

        public List<ProductoDto> GetProductos()
        {
            var db = new QueryFactory(connection, sqlKatacompiler);
            var producto = db.Query("Productos").Select(
                "Nombre", "Categoria", "Imagen"
                , "CantidadStock", "Precio"
                );
            var query = producto.Get<ProductoDto>();
            return query.ToList();
        }
    }
}