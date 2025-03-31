using AutoMapper;
using Galaxy.Tickets.Comun;
using Galaxy.Tickets.Dto.Request.Tickets;
using Galaxy.Tickets.Dto.Response;
using Galaxy.Tickets.Dto.Response.Tickets;
using Galaxy.Tickets.Entidades;
using Galaxy.Tickets.Repositorios.Interfaces;
using Galaxy.Tickets.Servicio.Interfaces;

namespace Galaxy.Tickets.Servicio.Implementaciones
{
	public class TicketServicio : ITicketServicio
	{
		private readonly ITicketRepositorio _repositorio;
		private readonly IMapper _mapper;

		public TicketServicio(ITicketRepositorio repositorio, IMapper mapper)
		{
			_repositorio = repositorio;
			_mapper = mapper;
		}

		public async Task<PaginacionResponse<ListaTicketsResponse>> Listar(BusquedaTicketsRequest request)
		{
			var respuesta = new PaginacionResponse<ListaTicketsResponse>();

			try
			{
				var resultado = await _repositorio.ListAsync(
					predicado: p => p.Estado &&
					                (string.IsNullOrEmpty(request.Titulo) || p.Titulo.Contains(request.Titulo)) &&
									(string.IsNullOrEmpty(request.Descripcion) || p.Descripcion.Contains(request.Descripcion)) &&
									(request.IdEstado == 0 || p.IdEstado == request.IdEstado) &&
									(request.IdCategoria == 0 || p.IdCategoria == request.IdCategoria) &&
									(request.IdPrioridad == 0 || p.IdPrioridad == request.IdPrioridad) &&
									(request.IdUsuarioAsignado == 0 || p.IdUsuarioAsignado == request.IdUsuarioAsignado) &&
									(request.IdUsuarioCreador == 0 || p.IdUsuarioCreador == request.IdUsuarioCreador),
					selector: p => new ListaTicketsResponse
					{
						Id = p.Id,
						Titulo = p.Titulo,
						UsuarioCreador = p.IdUsuarioCreadorNavigation.Nombre,
						UsuarioAsignado = p.IdUsuarioAsignadoNavigation!.Nombre,
						Categoria = p.IdCategoriaNavigation.Nombre,
						IdPrioridad = p.IdPrioridad,
						Prioridad = p.IdPrioridadNavigation.Nombre,
						IdEstado = p.IdEstado,
						Estado = p.IdEstadoNavigation.Nombre,
						FechaCreacion = p.FechaCreacion,
						FechaCierre = p.FechaCierre
					},
					orderBy: p => p.FechaCreacion,
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

		public async Task<BaseResponse<TicketResponse>> ObtenerPorId(int id)
		{
			var respuesta = new BaseResponse<TicketResponse>();

			try
			{
				var ticketResponse = await _repositorio.FindAsync(predicado: p => p.Estado &&
														                     p.Id == id,
																  selector: p => new TicketResponse
																  {
																	  Id = p.Id,
																	  Titulo = p.Titulo,
																	  Descripcion = p.Descripcion,
																	  IdUsuarioAsignado = p.IdUsuarioAsignado,
																	  IdUsuarioCreador = p.IdUsuarioCreador,
																	  UsuarioCreador = p.IdUsuarioCreadorNavigation!.Nombre,
																	  IdCategoria = p.IdCategoria,
																	  IdEstado = p.IdEstado,
																	  IdPrioridad = p.IdPrioridad,
																	  FechaCierre = p.FechaCierre,
																	  FechaCreacion = p.FechaCreacion
																  }) ?? 
					         throw new InvalidDataException("El ticket no existe");

				respuesta.Data = ticketResponse;
				respuesta.Success = true;
			}
			catch (Exception ex)
			{
				respuesta.Success = false;
				respuesta.Message = ex.Message;
			}

			return respuesta;
		}

		public async Task<BaseResponse> Registrar(TicketRequest request)
		{
			var respuesta = new BaseResponse();

			try
			{
				var ticket = _mapper.Map<Ticket>(request);
				await _repositorio.AddAsync(ticket);
				respuesta.Success = true;
				respuesta.Message = "Ticket creado con exito";
			}
			catch (Exception ex) {
				respuesta.Success = false;
				respuesta.Message = ex.Message;
			}

			return respuesta;
		}

		public async Task<BaseResponse> Actualizar(int id, TicketEditRequest request)
		{
			var respuesta = new BaseResponse();

			try
			{
				var ticket = await _repositorio.FindAsync(id) ?? 
					         throw new InvalidDataException("El ticket no existe");

				_mapper.Map(request, ticket);

				if (!string.IsNullOrEmpty(request.Comentario1))
				{
					ticket.Comentarios.Add(new Comentario 
					{ 
						Comentario1 = request.Comentario1,
						IdUsuario = 1,
						IdUsuarioCreador = 1
					});
				}

				await _repositorio.UpdateAsync();

				respuesta.Success = true;
				respuesta.Message = "Ticket actualizado con exito";
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
