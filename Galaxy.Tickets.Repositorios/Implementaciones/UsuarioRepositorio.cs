using Galaxy.Tickets.AccesoDatos.Contexto;
using Galaxy.Tickets.Entidades;
using Galaxy.Tickets.Repositorios.Interfaces;

namespace Galaxy.Tickets.Repositorios.Implementaciones
{
	public class UsuarioRepositorio(DbTicketsContext context) : RepositorioBase<Usuario>(context),
		                                                        IUsuarioRepositorio
	{
	}
}
