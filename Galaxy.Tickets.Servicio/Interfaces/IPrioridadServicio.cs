﻿using Galaxy.Tickets.Dto.Request.Prioridades;
using Galaxy.Tickets.Dto.Response.Prioridades;
using Galaxy.Tickets.Dto.Response;

namespace Galaxy.Tickets.Servicio.Interfaces
{
	public interface IPrioridadServicio
	{
		Task<PaginacionResponse<ListaPrioriadesResponse>> Listar(BusquedaPrioridadesRequest request);
		Task<BaseResponse<PrioridadResponse>> ObtenerPorId(int id);
		Task<BaseResponse> Registrar(PrioridadRequest request);
		Task<BaseResponse> Actualizar(int id, PrioridadRequest request);
		Task<BaseResponse> Eliminar(int id);
	}
}
