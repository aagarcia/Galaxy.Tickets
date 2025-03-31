namespace Galaxy.Tickets.Dto.Response.Tickets
{
	public class TicketResponse
	{
		public int Id { get; set; }
		public string Titulo { get; set; } = null!;

		public string Descripcion { get; set; } = null!;

		public int? IdUsuarioAsignado { get; set; }
		public int IdUsuarioCreador { get; set; }
		public string UsuarioCreador { get; set; }
		public int IdCategoria { get; set; }

		public int IdPrioridad { get; set; }

		public int IdEstado { get; set; }
		public DateTime FechaCreacion { get; set; }
		public DateTime? FechaCierre { get; set; }
	}
}
