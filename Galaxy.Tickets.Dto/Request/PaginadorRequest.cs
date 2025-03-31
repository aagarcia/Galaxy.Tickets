namespace Galaxy.Tickets.Dto.Request
{
	public class PaginadorRequest
	{
		public int PaginaActual { get; set; }
		public int FilasPorPagina { get; set; }
		public int TotalPaginas { get; set; }
		public int TotalRegistros { get; set; }
	}
}
