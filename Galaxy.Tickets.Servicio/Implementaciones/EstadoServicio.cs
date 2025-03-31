using AutoMapper;
using Galaxy.Tickets.Comun;
using Galaxy.Tickets.Dto.Request.Estados;
using Galaxy.Tickets.Dto.Response;
using Galaxy.Tickets.Dto.Response.Estados;
using Galaxy.Tickets.Entidades;
using Galaxy.Tickets.Repositorios.Interfaces;
using Galaxy.Tickets.Servicio.Interfaces;

namespace Galaxy.Tickets.Servicio.Implementaciones
{
	public class EstadoServicio : IEstadoServicio
	{
		private readonly IEstadoRepositorio _repositorio;
		private readonly IMapper _mapper;

		public EstadoServicio(IEstadoRepositorio repositorio, IMapper mapper)
		{
			_repositorio = repositorio;
			_mapper = mapper;
		}

		public async Task<PaginacionResponse<ListaEstadosResponse>> Listar(BusquedaEstadosRequest request)
		{
			var respuesta = new PaginacionResponse<ListaEstadosResponse>();

			try
			{
				var resultado = await _repositorio.ListAsync(
					predicado: p => p.Estado && (string.IsNullOrEmpty(request.Nombre) || p.Nombre.Contains(request.Nombre)),
					selector: p => new ListaEstadosResponse
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

		public async Task<BaseResponse<List<EstadoResponse>>> ListarTodos()
		{
			var respuesta = new BaseResponse<List<EstadoResponse>>();

			try
			{
				var resultado = await _repositorio.ListAsync();

				respuesta.Data = _mapper.Map<List<EstadoResponse>>(resultado);
				respuesta.Success = true;
			}
			catch (Exception ex)
			{
				respuesta.Success = false;
				respuesta.Message = ex.Message;
			}

			return respuesta;
		}

		public async Task<BaseResponse<EstadoResponse>> ObtenerPorId(int id)
		{
			var respuesta = new BaseResponse<EstadoResponse>();

			try
			{
				var estado = await _repositorio.FindAsync(id);
				if (estado == null) throw new InvalidDataException("El estado no existe");

				respuesta.Data = _mapper.Map<EstadoResponse>(estado);
				respuesta.Success = true;
			}
			catch (Exception ex)
			{
				respuesta.Success = false;
				respuesta.Message = ex.Message;
			}

			return respuesta;
		}

		public async Task<BaseResponse> Registrar(EstadoRequest request)
		{
			var respuesta = new BaseResponse();

			try
			{
				var estado = _mapper.Map<Estado>(request);
				await _repositorio.AddAsync(estado);
				respuesta.Success = true;
				respuesta.Message = "Estado registrado correctamente";
			}
			catch (Exception ex)
			{
				respuesta.Success = false;
				respuesta.Message = ex.Message;
			}

			return respuesta;
		}

		public async Task<BaseResponse> Actualizar(int id, EstadoRequest request)
		{
			var respuesta = new BaseResponse();

			try
			{
				var estado = await _repositorio.FindAsync(id);

				if (estado == null) throw new InvalidDataException("El estado no existe");

				_mapper.Map(request, estado);
				estado.FechaModificacion = DateTime.Now;
				estado.IdUsuarioModificador = 1;
				await _repositorio.UpdateAsync();

				respuesta.Success = true;
				respuesta.Message = "Estado actualizado correctamente";
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
				var estado = await _repositorio.FindAsync(id);

				if (estado == null) throw new InvalidDataException("El estado no existe");

				await _repositorio.DeleteAsync(id);

				respuesta.Success = true;
				respuesta.Message = "Estado eliminado correctamente";
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
