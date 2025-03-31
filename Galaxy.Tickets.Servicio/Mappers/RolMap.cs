using AutoMapper;
using Galaxy.Tickets.Dto.Request.Roles;
using Galaxy.Tickets.Dto.Response.Roles;
using Galaxy.Tickets.Entidades;

namespace Galaxy.Tickets.Servicio.Mappers
{
	public class RolMap : Profile
	{
		public RolMap()
		{
			CreateMap<RolRequest, Role>();
			CreateMap<Role, ListaRolesResponse>();
			CreateMap<Role, RolResponse>();
			//CreateMap<List<Role>, List<RolResponse>>();
		}
	}
}
