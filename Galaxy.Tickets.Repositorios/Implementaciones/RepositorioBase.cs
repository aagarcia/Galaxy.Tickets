using Galaxy.Tickets.AccesoDatos.Contexto;
using Galaxy.Tickets.Entidades;
using Galaxy.Tickets.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Galaxy.Tickets.Repositorios.Implementaciones
{
	public class RepositorioBase<TEntidad>(DbTicketsContext context) : IRepositorioBase<TEntidad> where TEntidad : EntidadBase
	{
		protected readonly DbTicketsContext _context = context;

		public async Task<ICollection<TEntidad>> ListAsync()
		{
			return await _context.Set<TEntidad>()
				                 .Where(p => p.Estado)
								 .AsNoTracking()
								 .ToListAsync();
		}

		public async Task<ICollection<TEntidad>> ListAsync(Expression<Func<TEntidad, bool>> predicado)
		{
			return await _context.Set<TEntidad>()
								 .Where(predicado)
								 .AsNoTracking()
								 .ToListAsync();
		}

		public async Task<ICollection<TResult>> ListAsync<TResult>(Expression<Func<TEntidad, bool>> predicado,
			                                                       Expression<Func<TEntidad, TResult>> selector)
		{
			return await _context.Set<TEntidad>()
								 .Where(predicado)
								 .AsNoTracking()
								 .Select(selector)
								 .ToListAsync();
		}

		public async Task<(ICollection<TResult> Coleccion, 
			               int TotalRegistros)> ListAsync<TResult, 
			                                              TKey>(Expression<Func<TEntidad, bool>> predicado,
																Expression<Func<TEntidad, TResult>> selector,
																Expression<Func<TEntidad, TKey>> orderBy,
																int pagina = 1,
																int filas = 5)
		{
			var resultado = await _context.Set<TEntidad>()
										  .Where(predicado)
										  .AsNoTracking()
										  .OrderBy(orderBy)
										  .Skip((pagina - 1) * filas)
										  .Take(filas)
										  .Select(selector)
										  .ToListAsync();

			var totalRegistros = await _context.Set<TEntidad>()
				                               .Where(predicado)
				                               .AsNoTracking()
											   .CountAsync();

			return (resultado, totalRegistros);
		}

		public async Task<TEntidad?> FindAsync(int id)
		{
			return await _context.Set<TEntidad>()
								 .FirstOrDefaultAsync(p => p.Id == id && p.Estado);
		}

		public async Task<TResult?> FindAsync<TResult>(Expression<Func<TEntidad, bool>> predicado,
													   Expression<Func<TEntidad, TResult>> selector)
		{
			var resultado = await _context.Set<TEntidad>()
										  .Where(predicado)
										  .AsNoTracking()
										  .Select(selector)
										  .ToListAsync();

			return resultado.FirstOrDefault();
		}

		public async Task<TEntidad> AddAsync(TEntidad entidad)
		{
			var resultado = await _context.Set<TEntidad>().AddAsync(entidad);

			await _context.SaveChangesAsync();

			return resultado.Entity;
		}

		public async Task UpdateAsync()
		{
			await _context.SaveChangesAsync();
		}

		public async Task DeleteAsync(int id)
		{
			// Obtener la hora actual en la zona horaria de Ecuador
			TimeZoneInfo ecuadorTimeZone = TimeZoneInfo.FindSystemTimeZoneById("SA Pacific Standard Time");
			DateTime ecuadorDateTime = TimeZoneInfo.ConvertTime(DateTime.UtcNow, ecuadorTimeZone);
			await _context.Set<TEntidad>()
						  .Where(p => p.Id == id)
						  .ExecuteUpdateAsync(p => p
							.SetProperty(p => p.Estado, false)
							.SetProperty(p => p.FechaModificacion, ecuadorDateTime)
							.SetProperty(p => p.IdUsuarioModificador, 1));
		}
	}
}
