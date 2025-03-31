using Galaxy.Tickets.Dto.Request.Estados;
using Galaxy.Tickets.Dto.Response.Estados;
using Galaxy.Tickets.Dto.Response;
using Galaxy.Tickets.Entidades;

namespace Galaxy.Tickets.Servicio.Interfaces
{
	public interface IEstadoServicio
	{
		Task<PaginacionResponse<ListaEstadosResponse>> Listar(BusquedaEstadosRequest request);
		Task<BaseResponse<List<EstadoResponse>>> ListarTodos();
		Task<BaseResponse<EstadoResponse>> ObtenerPorId(int id);
		Task<BaseResponse> Registrar(EstadoRequest request);
		Task<BaseResponse> Actualizar(int id, EstadoRequest request);
		Task<BaseResponse> Eliminar(int id);
	}
}
