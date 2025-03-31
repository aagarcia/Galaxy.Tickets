namespace Galaxy.Tickets.Dto.Response.Tickets
{
	public class ListaTicketsResponse
	{
		public int Id { get; set; }
		public string Titulo { get; set; } = null!;
		public string UsuarioCreador { get; set; } = null!;
		public string UsuarioAsignado { get; set; } = null!;
		public string Categoria { get; set; } = null!;
		public int IdPrioridad { get; set; }
		public string Prioridad { get; set; } = null!;
		public int IdEstado { get; set; }
		public string Estado { get; set; } = null!;
		public DateTime FechaCreacion { get; set; }
		public DateTime? FechaCierre { get; set; }
	}
}
