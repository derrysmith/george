using DS.George.Extensions.Core.Entities;

namespace DS.George.Extensions.Core.Services;

public interface IEntityRepository<TEntity, in TEntityKey>
	where TEntity : IEntity<TEntityKey>
{
	Task<TEntity> GetAsync(TEntityKey id, CancellationToken ct = default);

	Task<TEntity?> FindAsync(TEntityKey id, CancellationToken ct = default);
	
	void Append(TEntity entity);

	void Update(TEntity entity);

	void Remove(TEntityKey id);
}