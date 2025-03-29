﻿using Galaxy.Tickets.Dto.Request.Categorias;
using Galaxy.Tickets.Dto.Response;
using Galaxy.Tickets.Dto.Response.Categorias;

namespace Galaxy.Tickets.Servicio.Interfaces
{
	public interface ICategoriaServicio
	{
		Task<PaginacionResponse<ListaCategoriasResponse>> Listar(BusquedaCategoriasRequest request);
		Task<BaseResponse<CategoriaResponse>> ObtenerPorId(int id);
		Task<BaseResponse> Registrar(CategoriaRequest request);
		Task<BaseResponse> Actualizar(int id, CategoriaRequest request);
		Task<BaseResponse> Eliminar(int id);
	}
}
