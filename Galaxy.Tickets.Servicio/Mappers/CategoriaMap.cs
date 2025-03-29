using AutoMapper;
using Galaxy.Tickets.Dto.Request.Categorias;
using Galaxy.Tickets.Dto.Response.Categorias;
using Galaxy.Tickets.Entidades;

namespace Galaxy.Tickets.Servicio.Mappers
{
	public class CategoriaMap : Profile
	{
		public CategoriaMap()
		{
			CreateMap<CategoriaRequest, Categoria>().ReverseMap();
			CreateMap<Categoria, ListaCategoriasResponse>().ReverseMap();
			CreateMap<Categoria, CategoriaResponse>().ReverseMap();
		}
	}
}
