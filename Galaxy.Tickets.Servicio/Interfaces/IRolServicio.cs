using Galaxy.Tickets.Dto.Request.Roles;
using Galaxy.Tickets.Dto.Response.Roles;
using Galaxy.Tickets.Dto.Response;

namespace Galaxy.Tickets.Servicio.Interfaces
{
	public interface IRolServicio
	{
		Task<PaginacionResponse<ListaRolesResponse>> Listar(BusquedaRolesRequest request);
		Task<BaseResponse<RolResponse>> ObtenerPorId(int id);
		Task<BaseResponse> Registrar(RolRequest request);
		Task<BaseResponse> Actualizar(int id, RolRequest request);
		Task<BaseResponse> Eliminar(int id);
	}
}
