namespace Galaxy.Tickets.Dto.Request.Tickets
{
	public class BusquedaTicketsRequest : PaginacionRequest
	{
		public string Titulo { get; set; } = null!;

		public string Descripcion { get; set; } = null!;

		public int IdUsuarioAsignado { get; set; }

		public int IdCategoria { get; set; }

		public int IdPrioridad { get; set; }

		public int IdEstado { get; set; }

		public int IdUsuarioCreador { get; set; }
	}
}
