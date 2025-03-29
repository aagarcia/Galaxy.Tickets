using Galaxy.Tickets.AccesoDatos.Contexto;
using Galaxy.Tickets.Entidades;
using Galaxy.Tickets.Repositorios.Interfaces;

namespace Galaxy.Tickets.Repositorios.Implementaciones
{
	public class EstadoRepositorio(DbTicketsContext context) : RepositorioBase<Estado>(context), 
		                                                       IEstadoRepositorio
	{
	}
}
