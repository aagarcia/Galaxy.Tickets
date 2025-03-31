using AutoMapper;
using Galaxy.Tickets.Comun;
using Galaxy.Tickets.Dto.Request.Prioridades;
using Galaxy.Tickets.Dto.Response;
using Galaxy.Tickets.Dto.Response.Prioridades;
using Galaxy.Tickets.Entidades;
using Galaxy.Tickets.Repositorios.Interfaces;
using Galaxy.Tickets.Servicio.Interfaces;

namespace Galaxy.Tickets.Servicio.Implementaciones
{
	public class PrioridadServicio : IPrioridadServicio
	{
		private readonly IPrioridadRepositorio _repositorio;
		private readonly IMapper _mapper;

		public PrioridadServicio(IPrioridadRepositorio repositorio, IMapper mapper)
		{
			_repositorio = repositorio;
			_mapper = mapper;
		}

		public async Task<PaginacionResponse<ListaPrioriadesResponse>> Listar(BusquedaPrioridadesRequest request)
		{
			var respuesta = new PaginacionResponse<ListaPrioriadesResponse>();

			try
			{
				var resultado = await _repositorio.ListAsync(
					predicado: p => p.Estado && (string.IsNullOrEmpty(request.Nombre) || p.Nombre.Contains(request.Nombre)),
					selector: p => new ListaPrioriadesResponse
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

		public async Task<BaseResponse<List<PrioridadResponse>>> ListarTodos()
		{
			var respuesta = new BaseResponse<List<PrioridadResponse>>();

			try
			{
				var resultado = await _repositorio.ListAsync();

				respuesta.Data = _mapper.Map<List<PrioridadResponse>>(resultado);
				respuesta.Success = true;
			}
			catch (Exception ex)
			{
				respuesta.Success = false;
				respuesta.Message = ex.Message;
			}

			return respuesta;
		}

		public async Task<BaseResponse<PrioridadResponse>> ObtenerPorId(int id)
		{
			var respuesta = new BaseResponse<PrioridadResponse>();

			try
			{
				var prioridad = await _repositorio.FindAsync(id);

				if (prioridad == null) throw new InvalidDataException("La prioridad no existe");

				respuesta.Data = _mapper.Map<PrioridadResponse>(prioridad);
				respuesta.Success = true;
			}
			catch (Exception ex)
			{
				respuesta.Success = false;
				respuesta.Message = ex.Message;
			}

			return respuesta;
		}

		public async Task<BaseResponse> Registrar(PrioridadRequest request)
		{
			var respuesta = new BaseResponse();

			try
			{
				var prioridad = _mapper.Map<Prioridade>(request);	

				await _repositorio.AddAsync(prioridad);

				respuesta.Success = true;
				respuesta.Message = "Prioridad creada con exito";			
			}
			catch (Exception ex)
			{
				respuesta.Success = false;
				respuesta.Message = ex.Message;
			}

			return respuesta;
		}

		public async Task<BaseResponse> Actualizar(int id, PrioridadRequest request)
		{
			var respuesta = new BaseResponse();

			try
			{
				var prioridad = await _repositorio.FindAsync(id);

				if (prioridad == null) throw new InvalidDataException("La prioridad no existe");

				_mapper.Map(request, prioridad);
				prioridad.IdUsuarioModificador = 1;
				prioridad.FechaModificacion = DateTime.Now;
				await _repositorio.UpdateAsync();

				respuesta.Success = true;
				respuesta.Message = "Prioridad actualizada con exito";
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
				var prioridad = await _repositorio.FindAsync(id);

				if (prioridad == null) throw new InvalidDataException("La prioridad no existe");

				await _repositorio.DeleteAsync(id);

				respuesta.Success = true;
				respuesta.Message = "Prioridad eliminada con exito";
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
