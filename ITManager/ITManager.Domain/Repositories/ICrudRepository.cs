using ITManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITManager.Domain.Repositories
{
    public interface ICrudRepository<T> where T : BaseEntity
    {
        Task Create(T entity);
        Task Delete(int id);
        Task Delete(T entity);
        Task<T> GetById(int id);
        IQueryable<T> GetAll();
        Task Update(T entity);
    }
}
