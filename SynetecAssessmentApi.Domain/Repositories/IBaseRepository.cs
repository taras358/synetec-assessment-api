using System.Collections.Generic;
using System.Threading.Tasks;
using SynetecAssessmentApi.Domain.Entities;

namespace SynetecAssessmentApi.Domain.Repositories
{
    public interface IBaseRepository<TEntity> where TEntity : Entity
    {
        Task CreateAsync(TEntity model);
        Task DeleteAsync(TEntity model);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(long id);
        Task SaveChangesAsync();
        Task UpdateAsync(TEntity model);
    }
}