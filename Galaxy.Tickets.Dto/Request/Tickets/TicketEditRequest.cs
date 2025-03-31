namespace Galaxy.Tickets.Dto.Request.Tickets
{
	public class TicketEditRequest
	{
		public int? IdUsuarioAsignado { get; set; }

		public int? IdCategoria { get; set; }

		public int? IdPrioridad { get; set; }

		public int? IdEstado { get; set; }

		public DateTime? FechaCierre { get; set; }

		public string Comentario1 { get; set; }
	}
}
