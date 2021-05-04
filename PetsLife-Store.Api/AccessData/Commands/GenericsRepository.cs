using AccessData.Commands.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessData.Commands
{
    public class GenericsRepository : IGenericsRepository
    {
        private readonly ApplicationDbContext _context;
        public GenericsRepository(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
            _context.SaveChanges();
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
            _context.SaveChanges();
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public T Exists<T>(int id) where T : class
        {
            var x = _context.Find<T>(id);
            return x;
        }

        public IQueryable GetProductoById(int id)
        {
            var query = from tbl1 in _context.Productos
                        where tbl1.ProductoId == id
                        select new
                        {
                            productoid = tbl1.ProductoId,
                            nombre = tbl1.Nombre,
                            precio = tbl1.Precio,
                            stock = tbl1.CantidadStock,
                            categoria = tbl1.Categoria,

                        };
            return query;
        }

        public IQueryable GetProductos()
        {
            var query = from tbl1 in _context.Productos
                        select new
                        {
                            productoid = tbl1.ProductoId,
                            nombre = tbl1.Nombre,
                            precio = tbl1.Precio,
                            stock = tbl1.CantidadStock,
                            categoria = tbl1.Categoria,

                        };
            return query;
        }
    }
}
