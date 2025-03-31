using Galaxy.Tickets.Comun;
using System.ComponentModel.DataAnnotations;

namespace Galaxy.Tickets.Dto.Request.Tickets
{
	public class TicketEditRequest
	{
		[Required(ErrorMessage = Constantes.MensajeRequired)]
		[DeniedValues(0, ErrorMessage = Constantes.MensajeRequired)]
		[Display(Name = "Usuario Asignado")]
		public int? IdUsuarioAsignado { get; set; }

		[Required(ErrorMessage = Constantes.MensajeRequired)]
		[DeniedValues(0, ErrorMessage = Constantes.MensajeRequired)]
		[Display(Name = "Categoria")]
		public int? IdCategoria { get; set; }

		[Required(ErrorMessage = Constantes.MensajeRequired)]
		[DeniedValues(0, ErrorMessage = Constantes.MensajeRequired)]
		[Display(Name = "Prioridad")]
		public int? IdPrioridad { get; set; }

		[Required(ErrorMessage = Constantes.MensajeRequired)]
		[DeniedValues(0, ErrorMessage = Constantes.MensajeRequired)]
		[Display(Name = "Estado")]
		public int? IdEstado { get; set; }

		public DateTime? FechaCierre { get; set; }

		public string? Comentario1 { get; set; }
	}
}
