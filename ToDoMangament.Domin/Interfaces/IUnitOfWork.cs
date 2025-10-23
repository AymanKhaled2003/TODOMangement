using ToDoMangament.Domain.Primitives;
using ToDoMangament.Domain.Interfaces;
using ToDoMangament.Domain.Entities;

namespace ToDoMangament.Domain.Interfaces;

public interface IUnitOfWork
{
    Task<int> CompleteAsync(CancellationToken cancellationToken = default);
    IGenericRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity;
}
