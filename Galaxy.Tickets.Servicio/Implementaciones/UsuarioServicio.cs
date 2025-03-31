using AutoMapper;
using Galaxy.Tickets.Comun;
using Galaxy.Tickets.Dto.Request.Usuarios;
using Galaxy.Tickets.Dto.Response;
using Galaxy.Tickets.Dto.Response.Usuarios;
using Galaxy.Tickets.Entidades;
using Galaxy.Tickets.Repositorios.Interfaces;
using Galaxy.Tickets.Servicio.Interfaces;

namespace Galaxy.Tickets.Servicio.Implementaciones
{
	public class UsuarioServicio : IUsuarioServicio
	{
		private readonly IUsuarioRepositorio _repositorio;
		private readonly IMapper _mapper;

		public UsuarioServicio(IUsuarioRepositorio repositorio, IMapper mapper)
		{
			_repositorio = repositorio;
			_mapper = mapper;
		}

		public async Task<PaginacionResponse<ListaUsuariosResponse>> Listar(BusquedaUsuariosRequest request)
		{
			var respuesta = new PaginacionResponse<ListaUsuariosResponse>();

			try
			{
				var resultado = await _repositorio.ListAsync(
					predicado: p => p.Estado &&
									(request.IdRol == 0 || p.IdRol == request.IdRol) &&
									(string.IsNullOrEmpty(request.Nombre) || p.Nombre.Contains(request.Nombre)) &&
									(string.IsNullOrEmpty(request.Email) || p.Email.Contains(request.Email)),
					selector: p => new ListaUsuariosResponse
					{
						Id = p.Id,
						Nombre = p.Nombre,
						Email = p.Email,
						Rol = p.IdRolNavigation.Nombre
					},
					orderBy: p => p.Nombre,
					pagina: request.Pagina,
					filas: request.Filas);

				respuesta.Data = resultado.Coleccion;
				respuesta.Success = true;
				respuesta.TotalFilas = resultado.TotalRegistros;
				respuesta.TotalPaginas = Helpers.CalcularNumeroPaginas(resultado.TotalRegistros, request.Filas);
			}
			catch (Exception ex)
			{
				respuesta.Success = false;
				respuesta.Message = ex.Message;
			}

			return respuesta;
		}

		public async Task<BaseResponse<List<UsuarioResponse>>> ListarTodosClientes()
		{
			var respuesta = new BaseResponse<List<UsuarioResponse>>();

			try
			{ 
				var resultado = await _repositorio.ListAsync(predicado: p => p.IdRol == 3 && p.Estado);
				respuesta.Data = _mapper.Map<List<UsuarioResponse>>(resultado);
				respuesta.Success = true;
			}
			catch (Exception ex)
			{
				respuesta.Success = false;
				respuesta.Message = ex.Message;
			}

			return respuesta;
		}

		public async Task<BaseResponse<List<UsuarioResponse>>> ListarTodosSoportes()
		{
			var respuesta = new BaseResponse<List<UsuarioResponse>>();

			try
			{
				var resultado = await _repositorio.ListAsync(predicado: p => p.IdRol == 2 && p.Estado);
				respuesta.Data = _mapper.Map<List<UsuarioResponse>>(resultado);
				respuesta.Success = true;
			}
			catch (Exception ex)
			{
				respuesta.Success = false;
				respuesta.Message = ex.Message;
			}

			return respuesta;
		}

		public async Task<BaseResponse<UsuarioResponse>> ObtenerPorId(int id)
		{
			var respuesta = new BaseResponse<UsuarioResponse>();

			try
			{
				var usuario = await _repositorio.FindAsync(id);
				if (usuario == null) throw new InvalidDataException("El usuario no existe");

				respuesta.Data = _mapper.Map<UsuarioResponse>(usuario);
				respuesta.Success = true;
			}
			catch (Exception ex)
			{
				respuesta.Success = false;
				respuesta.Message = ex.Message;
			}

			return respuesta;
		}

		public async Task<BaseResponse> Registrar(UsuarioRequest request)
		{
			var respuesta = new BaseResponse();

			try
			{
				var usuario = _mapper.Map<Usuario>(request);
				await _repositorio.AddAsync(usuario);
				respuesta.Success = true;
				respuesta.Message = "Usuario registrado correctamente";
			}
			catch (Exception ex)
			{
				respuesta.Success = false;
				respuesta.Message = ex.Message;
			}

			return respuesta;
		}

		public async Task<BaseResponse> Actualizar(int id, UsuarioRequest request)
		{ 
			var respuesta = new BaseResponse();

			try
			{
				var usuario = await _repositorio.FindAsync(id);

				if (usuario == null) throw new InvalidDataException("El usuario no existe");

				_mapper.Map(request, usuario);
				usuario.IdUsuarioModificador = 1;
				usuario.FechaModificacion = DateTime.Now;
				await _repositorio.UpdateAsync();

				respuesta.Success = true;
				respuesta.Message = "Usuario actualizado correctamente";
			}
			catch (Exception ex)
			{
				respuesta.Success = false;
				respuesta.Message = ex.Message;
			}

			return respuesta;
		}

		public async Task<BaseResponse> Eliminar(int id)
		{
			var respuesta = new BaseResponse();

			try
			{
				var usuario = await _repositorio.FindAsync(id);

				if (usuario == null) throw new InvalidDataException("El usuario no existe");

				if (id == 1) throw new InvalidDataException("No se puede eliminar el usuario administrador");

				await _repositorio.DeleteAsync(id);
				respuesta.Success = true;
				respuesta.Message = "Usuario eliminado correctamente";
			}
			catch (Exception ex)
			{
				respuesta.Success = false;
				respuesta.Message = ex.Message;
			}

			return respuesta;
		}
	}
}
