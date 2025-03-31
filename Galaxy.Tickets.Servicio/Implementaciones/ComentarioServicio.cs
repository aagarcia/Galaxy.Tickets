using AutoMapper;
using Galaxy.Tickets.Comun;
using Galaxy.Tickets.Dto.Request;
using Galaxy.Tickets.Dto.Response;
using Galaxy.Tickets.Dto.Response.Comentarios;
using Galaxy.Tickets.Repositorios.Interfaces;
using Galaxy.Tickets.Servicio.Interfaces;

namespace Galaxy.Tickets.Servicio.Implementaciones
{
	public class ComentarioServicio : IComentarioServicio
	{
		private readonly IComentarioRepositorio _repositorio;

		public ComentarioServicio(IComentarioRepositorio repositorio)
		{
			_repositorio = repositorio;
		}

		public async Task<PaginacionResponse<ListaComentarioResponse>> Listar(int idTicket,
																			  PaginacionRequest request)
		{
			var respuesta = new PaginacionResponse<ListaComentarioResponse>();

			try
			{
				var resultado = await _repositorio.ListAsync(predicado: p => p.Estado &&
				                                                             p.IdTicket == idTicket,
											                 selector: p => new ListaComentarioResponse
															 {
																 NombreUsuario = p.IdUsuarioNavigation!.Nombre,
																 Comentario = p.Comentario1,
																 FechaCreacion = p.FechaCreacion
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
	}
}
