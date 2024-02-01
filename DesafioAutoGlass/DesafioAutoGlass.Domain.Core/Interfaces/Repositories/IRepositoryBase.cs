namespace DesafioAutoGlass.Domain.Core.Interfaces.Repositories
{
    public interface IRepositoryBase<TEntity>: IDisposable where TEntity : class
    {

        Task Add(TEntity entity);
        
        Task Update(TEntity entity);

        Task Delete(TEntity entity);
        
        Task<TEntity> Get(int entityId);
        
        Task<List<TEntity>> GetAll();

        void Detach(Func<TEntity, bool> predicate);
    }
}
