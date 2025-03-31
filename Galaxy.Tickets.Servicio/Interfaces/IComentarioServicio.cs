using Galaxy.Tickets.Dto.Response.Comentarios;
using Galaxy.Tickets.Dto.Response;
using Galaxy.Tickets.Dto.Request;

namespace Galaxy.Tickets.Servicio.Interfaces
{
	public interface IComentarioServicio
	{
		Task<PaginacionResponse<ListaComentarioResponse>> Listar(int idTicket,
																 PaginacionRequest request);
	}
}
