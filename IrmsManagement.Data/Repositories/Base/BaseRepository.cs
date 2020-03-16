using IrmsManagement.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrmsManagement.Data.Repositories.Base
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class, IEntity
    {
        private readonly IrmsManagementDbContext _dbContext;

        public BaseRepository(IrmsManagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public async Task<TEntity> GetById(int id)
        {
            return await _dbContext.Set<TEntity>()
                .AsNoTracking()
                .FirstOrDefaultAsync(f => f.Id == id);
        }
        
        public void Add(TEntity entity)
        {
            _dbContext.Set<TEntity>().Add(entity);
        }

        public async Task Delete(int id)
        {
            var entity = await GetById(id);
            _dbContext.Set<TEntity>().Remove(entity);
        }

        public void Delete(TEntity entity)
        {
            _dbContext.Set<TEntity>().Remove(entity);
        }

        public void Update(TEntity entity)
        {
            _dbContext.Set<TEntity>().Update(entity);
        }
        
        public async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public DbSet<TEntity> Table
        {
            get
            {
                return _dbContext.Set<TEntity>();
            }
        }
    }
}
