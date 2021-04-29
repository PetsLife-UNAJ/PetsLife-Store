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
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}
