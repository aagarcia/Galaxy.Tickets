using AutoMapper;
using Galaxy.Tickets.Dto.Request.Estados;
using Galaxy.Tickets.Dto.Response.Estados;
using Galaxy.Tickets.Entidades;

namespace Galaxy.Tickets.Servicio.Mappers
{
	public class EstadoMap : Profile
	{
		public EstadoMap() 
		{
			CreateMap<EstadoRequest, Estado>();
			CreateMap<Estado, ListaEstadosResponse>();
			CreateMap<Estado, EstadoResponse>();
		}
	}
}
