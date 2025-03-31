using AutoMapper;
using Galaxy.Tickets.Comun;
using Galaxy.Tickets.Dto.Request.Categorias;
using Galaxy.Tickets.Dto.Response;
using Galaxy.Tickets.Dto.Response.Categorias;
using Galaxy.Tickets.Entidades;
using Galaxy.Tickets.Repositorios.Interfaces;
using Galaxy.Tickets.Servicio.Interfaces;

namespace Galaxy.Tickets.Servicio.Implementaciones
{
	public class CategoriaServicio : ICategoriaServicio
	{
		private readonly ICategoriaRepositorio _repositorio;
		private readonly IMapper _mapper;

		public CategoriaServicio(ICategoriaRepositorio repositorio,
								 IMapper mapper)
		{
			_repositorio = repositorio;
			_mapper = mapper;
		}

		public async Task<PaginacionResponse<ListaCategoriasResponse>> Listar(BusquedaCategoriasRequest request)
		{
			var respuesta = new PaginacionResponse<ListaCategoriasResponse>();

			try
			{
				var resultado = await _repositorio.ListAsync(
					predicado: p => p.Estado &&
								   (string.IsNullOrEmpty(request.Nombre) || p.Nombre.Contains(request.Nombre)),
					selector: p => new ListaCategoriasResponse
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

		public async Task<BaseResponse<List<CategoriaResponse>>> ListarTodos()
		{
			var respuesta = new BaseResponse<List<CategoriaResponse>>();

			try
			{
				var categorias = await _repositorio.ListAsync();
				respuesta.Data = _mapper.Map<List<CategoriaResponse>>(categorias);
				respuesta.Success = true;
			}
			catch (Exception ex)
			{
				respuesta.Success = false;
				respuesta.Message = ex.Message;
			}

			return respuesta;
		}

		public async Task<BaseResponse<CategoriaResponse>> ObtenerPorId(int id)
		{
			var respuesta = new BaseResponse<CategoriaResponse>();

			try
			{
				var categoria = await _repositorio.FindAsync(id);
				if (categoria == null) throw new InvalidDataException("La categoria no existe");

				respuesta.Data = _mapper.Map<CategoriaResponse>(categoria);
				respuesta.Success = true;
			}
			catch (Exception ex)
			{
				respuesta.Success = false;
				respuesta.Message = ex.Message;
			}

			return respuesta;
		}

		public async Task<BaseResponse> Registrar(CategoriaRequest request)
		{
			var respuesta = new BaseResponse();

			try
			{
				var categoria = _mapper.Map<Categoria>(request);

				await _repositorio.AddAsync(categoria);

				respuesta.Success = true;
				respuesta.Message = "Categoria creada con exito";
			}
			catch (Exception ex)
			{
				respuesta.Success = false;
				respuesta.Message = ex.Message;
			}

			return respuesta;
		}

		public async Task<BaseResponse> Actualizar(int id, CategoriaRequest request)
		{
			var respuesta = new BaseResponse();

			try
			{
				var categoria = await _repositorio.FindAsync(id);

				if (categoria == null) throw new InvalidDataException("La categoria no existe");

				_mapper.Map(request, categoria);
				categoria.IdUsuarioModificador = 1;
				categoria.FechaModificacion = DateTime.Now;
				await _repositorio.UpdateAsync();

				respuesta.Success = true;
				respuesta.Message = "Categoria actualizada con exito";
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
				var categoria = await _repositorio.FindAsync(id);

				if (categoria == null) throw new InvalidDataException("La categoria no existe");

				await _repositorio.DeleteAsync(id);

				respuesta.Success = true;
				respuesta.Message = "Categoria eliminada con exito";
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
