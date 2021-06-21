using Domain.DTOs;
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
    public class CategoriaQuery : ICategoriaQuery
    {
        private readonly IDbConnection connection;
        private readonly Compiler sqlKatacompiler;

        public CategoriaQuery(IDbConnection connection, Compiler sqlKatacompiler)
        {
            this.connection = connection;
            this.sqlKatacompiler = sqlKatacompiler;
        }

        public List<GetCategoriaDto> GetAllCategorias()
        {
            var db = new QueryFactory(connection, sqlKatacompiler);
            var query = db.Query("Categorias")
                .Select("Categorias.CategoriaId",
                "Categorias.Descripcion");
            var result = query.Get<GetCategoriaDto>();
            return result.ToList();
        }
    }
}
