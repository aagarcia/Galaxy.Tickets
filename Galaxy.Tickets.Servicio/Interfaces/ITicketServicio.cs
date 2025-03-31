using Galaxy.Tickets.Dto.Request.Tickets;
using Galaxy.Tickets.Dto.Response.Tickets;
using Galaxy.Tickets.Dto.Response;

namespace Galaxy.Tickets.Servicio.Interfaces
{
	public interface ITicketServicio
	{
		Task<PaginacionResponse<ListaTicketsResponse>> Listar(BusquedaTicketsRequest request);
		Task<BaseResponse<TicketResponse>> ObtenerPorId(int id);
		Task<BaseResponse> Registrar(TicketRequest request);
		Task<BaseResponse> Actualizar(int id, TicketEditRequest request);
	}
}
