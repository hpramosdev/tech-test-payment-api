using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using tech_test_payment_api.Context;
using tech_test_payment_api.Repositories.Interfaces;

namespace tech_test_payment_api.Repositories
{
public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        protected readonly DataContext _context;
        private bool disposed = false;

        public BaseRepository(DataContext context)
            => _context = context;

        public async Task<IEnumerable<TEntity>> GetAll()
            => await _context.Set<TEntity>().ToListAsync();

        public async Task<TEntity> GetById(Guid id)
            => await _context.Set<TEntity>().FindAsync(id);

        public async Task Create(TEntity model) 
            => await _context.AddAsync(model);             

        public void Update(TEntity model)
            => _context.Entry(model).State = EntityState.Modified;                

        public void Delete(TEntity model)
            => _context.Remove(model);

        ~BaseRepository()
            => Dispose();
        
        public void Dispose()  
        {
            if (!disposed)
                _context.Dispose();

            GC.SuppressFinalize(this);
        }
    }
}