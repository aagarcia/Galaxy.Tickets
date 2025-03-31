using Galaxy.Tickets.Entidades;
using System.Linq.Expressions;

namespace Galaxy.Tickets.Repositorios.Interfaces
{
	public interface IRepositorioBase<TEntidad> where TEntidad : EntidadBase
	{
		Task<ICollection<TEntidad>> ListAsync();

		Task<ICollection<TEntidad>> ListAsync(Expression<Func<TEntidad, bool>> predicado);
		Task<ICollection<TResult>> ListAsync<TResult>(Expression<Func<TEntidad, bool>> predicado,
													  Expression<Func<TEntidad, TResult>> selector);
		Task<(ICollection<TResult> Coleccion,
						  int TotalRegistros)> ListAsync<TResult,
														 TKey>(Expression<Func<TEntidad, bool>> predicado,
															   Expression<Func<TEntidad, TResult>> selector,
															   Expression<Func<TEntidad, TKey>> orderBy,
															   int pagina = 1,
															   int filas = 5);
		Task<TEntidad?> FindAsync(int id);
		Task<TResult?> FindAsync<TResult>(Expression<Func<TEntidad, bool>> predicado,
										  Expression<Func<TEntidad, TResult>> selector);
		Task<TEntidad> AddAsync(TEntidad entidad);
		Task UpdateAsync();
		Task DeleteAsync(int id);
	}
}
