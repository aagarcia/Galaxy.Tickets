using AutoMapper;
using Galaxy.Tickets.Dto.Request.Tickets;
using Galaxy.Tickets.Dto.Response.Tickets;
using Galaxy.Tickets.Entidades;

namespace Galaxy.Tickets.Servicio.Mappers
{
	public class TicketMap : Profile
	{
		public TicketMap()
		{
			CreateMap<TicketRequest, Ticket>();
			CreateMap<Ticket, ListaTicketsResponse>()
				.ForMember(p => p.Categoria, o => o.MapFrom(o => o.IdCategoriaNavigation.Nombre))
				.ForMember(p => p.Prioridad, o => o.MapFrom(o => o.IdPrioridadNavigation.Nombre))
				.ForMember(p => p.Estado, o => o.MapFrom(o => o.IdEstadoNavigation.Nombre))
				.ForMember(p => p.UsuarioCreador, o => o.MapFrom(o => o.IdUsuarioCreadorNavigation.Nombre))
				.ForMember(p => p.UsuarioAsignado, o => o.MapFrom(o => o.IdUsuarioAsignadoNavigation!.Nombre ?? "Sin Asignar"));
		}
	}
}
