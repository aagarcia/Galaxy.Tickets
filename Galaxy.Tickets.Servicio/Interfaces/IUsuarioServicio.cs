using Galaxy.Tickets.Dto.Request.Usuarios;
using Galaxy.Tickets.Dto.Response.Usuarios;
using Galaxy.Tickets.Dto.Response;
using Galaxy.Tickets.Entidades;

namespace Galaxy.Tickets.Servicio.Interfaces
{
	public interface IUsuarioServicio
	{
		Task<PaginacionResponse<ListaUsuariosResponse>> Listar(BusquedaUsuariosRequest request);
		Task<BaseResponse<List<UsuarioResponse>>> ListarTodosClientes();
		Task<BaseResponse<List<UsuarioResponse>>> ListarTodosSoportes();
		Task<BaseResponse<UsuarioResponse>> ObtenerPorId(int id);
		Task<BaseResponse> Registrar(UsuarioRequest request);
		Task<BaseResponse> Actualizar(int id, UsuarioRequest request);
		Task<BaseResponse> Eliminar(int id);
	}
}
