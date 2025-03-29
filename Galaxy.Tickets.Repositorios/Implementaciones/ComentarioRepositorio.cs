using Galaxy.Tickets.AccesoDatos.Contexto;
using Galaxy.Tickets.Entidades;
using Galaxy.Tickets.Repositorios.Interfaces;

namespace Galaxy.Tickets.Repositorios.Implementaciones
{
	public class ComentarioRepositorio(DbTicketsContext context) : RepositorioBase<Comentario>(context),
		                                                           IComentarioRepositorio
	{

	}
}
