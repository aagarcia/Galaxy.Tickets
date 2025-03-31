using AutoMapper;
using Galaxy.Tickets.Dto.Request.Usuarios;
using Galaxy.Tickets.Dto.Response.Usuarios;
using Galaxy.Tickets.Entidades;

namespace Galaxy.Tickets.Servicio.Mappers
{
	public class UsuarioMap : Profile
	{
		public UsuarioMap()
		{
			CreateMap<UsuarioRequest, Usuario>();
			CreateMap<Usuario, ListaUsuariosResponse>()
				.ForMember(p => p.Rol, o => o.MapFrom(o => o.IdRolNavigation.Nombre));
			CreateMap<Usuario, UsuarioResponse>();
		}
	}
}
