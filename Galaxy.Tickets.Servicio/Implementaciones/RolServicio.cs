using AutoMapper;
using Galaxy.Tickets.Comun;
using Galaxy.Tickets.Dto.Request.Roles;
using Galaxy.Tickets.Dto.Response;
using Galaxy.Tickets.Dto.Response.Roles;
using Galaxy.Tickets.Entidades;
using Galaxy.Tickets.Repositorios.Interfaces;
using Galaxy.Tickets.Servicio.Interfaces;

namespace Galaxy.Tickets.Servicio.Implementaciones
{
	public class RolServicio : IRolServicio
	{
		private readonly IRoleRepositorio _repositorio;
		private readonly IMapper _mapper;

		public RolServicio(IRoleRepositorio repositorio, IMapper mapper)
		{
			_repositorio = repositorio;
			_mapper = mapper;
		}

		public async Task<PaginacionResponse<ListaRolesResponse>> Listar(BusquedaRolesRequest request)
		{
			var respuesta = new PaginacionResponse<ListaRolesResponse>();

			try
			{
				var resultado = await _repositorio.ListAsync(
					predicado: p => p.Estado && (string.IsNullOrEmpty(request.Nombre) || p.Nombre.Contains(request.Nombre)),
					selector: p => new ListaRolesResponse
					{
						Id = p.Id,
						Nombre = p.Nombre
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

		public async Task<BaseResponse<RolResponse>> ObtenerPorId(int id)
		{
			var respuesta = new BaseResponse<RolResponse>();

			try
			{
				var rol = await _repositorio.FindAsync(id);
				if (rol == null) throw new InvalidDataException("El rol no existe");

				respuesta.Data = _mapper.Map<RolResponse>(rol);
				respuesta.Success = true;
			}
			catch (Exception ex)
			{
				respuesta.Success = false;
				respuesta.Message = ex.Message;
			}

			return respuesta;
		}

		public async Task<BaseResponse> Registrar(RolRequest request)
		{
			var respuesta = new BaseResponse();

			try
			{
				var rol = _mapper.Map<Role>(request);
				await _repositorio.AddAsync(rol);
				respuesta.Success = true;
				respuesta.Message = "Rol creado con exito";
			}
			catch (Exception ex)
			{
				respuesta.Success = false;
				respuesta.Message = ex.Message;
			}

			return respuesta;
		}

		public async Task<BaseResponse> Actualizar(int id, RolRequest request)
		{
			var respuesta = new BaseResponse();

			try
			{
				var rol = await _repositorio.FindAsync(id);
				if (rol == null) throw new InvalidDataException("El rol no existe");

				_mapper.Map(request, rol);
				rol.IdUsuarioModificador = 1;
				rol.FechaModificacion = DateTime.Now;
				await _repositorio.UpdateAsync();

				respuesta.Success = true;
				respuesta.Message = "Rol actualizado con exito";
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
				var rol = await _repositorio.FindAsync(id);
				if (rol == null) throw new InvalidDataException("El rol no existe");

				await _repositorio.DeleteAsync(id);

				respuesta.Success = true;
				respuesta.Message = "Rol eliminado con exito";
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
