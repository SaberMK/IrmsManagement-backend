using IrmsManagement.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrmsManagement.Data.Repositories.Base
{
    public interface IBaseRepository<TEntity> where TEntity : class, IEntity
    {
        Task<TEntity> GetById(int id);
        
        void Add(TEntity entity);

        Task Delete(int id);
        
        void Update(TEntity entity);
        
        Task SaveAsync();

        DbSet<TEntity> Table { get; }
    }
}
