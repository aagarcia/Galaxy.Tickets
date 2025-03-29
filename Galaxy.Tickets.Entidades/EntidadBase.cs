namespace Galaxy.Tickets.Entidades
{
	public class EntidadBase
	{
		public int Id { get; set; }
		public bool Estado { get; set; } = true;

		public int IdUsuarioCreador { get; set; } = 1;

		public int? IdUsuarioModificador { get; set; }

		public DateTime FechaCreacion { get; set; } = DateTime.Now;

		public DateTime? FechaModificacion { get; set; }
	}
}
