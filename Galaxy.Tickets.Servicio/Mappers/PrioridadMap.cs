using AutoMapper;
using Galaxy.Tickets.Dto.Request.Prioridades;
using Galaxy.Tickets.Dto.Response.Prioridades;
using Galaxy.Tickets.Entidades;

namespace Galaxy.Tickets.Servicio.Mappers
{
	public class PrioridadMap : Profile
	{
		public PrioridadMap() 
		{
			CreateMap<PrioridadRequest, Prioridade>();
			CreateMap<Prioridade, ListaPrioriadesResponse>();
			CreateMap<Prioridade, PrioridadResponse>();
		}
	}
}
