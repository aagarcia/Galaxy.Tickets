using Galaxy.Tickets.Comun;
using System.ComponentModel.DataAnnotations;

namespace Galaxy.Tickets.Dto.Request.Tickets
{
	public class TicketRequest
	{
		[Required(ErrorMessage = Constantes.MensajeRequired)]
		[Display(Name = "Título")]
		public string Titulo { get; set; }

		[Required(ErrorMessage = Constantes.MensajeRequired)]
		[Display(Name = "Descripción")]
		public string Descripcion { get; set; }

		[Required(ErrorMessage = Constantes.MensajeRequired)]
		[DeniedValues(0, ErrorMessage = Constantes.MensajeRequired)]
		[Display(Name = "Usuario Asignado")]
		public int? IdUsuarioAsignado { get; set; }

		[Required(ErrorMessage = Constantes.MensajeRequired)]
		[DeniedValues(0, ErrorMessage = Constantes.MensajeRequired)]
		[Display(Name = "Categoria")]
		public int IdCategoria { get; set; }

		[Required(ErrorMessage = Constantes.MensajeRequired)]
		[DeniedValues(0, ErrorMessage = Constantes.MensajeRequired)]
		[Display(Name = "Prioridad")]
		public int IdPrioridad { get; set; }

		public int IdEstado { get; set; } = 1;

		[Required(ErrorMessage = Constantes.MensajeRequired)]
		[DeniedValues(0, ErrorMessage = Constantes.MensajeRequired)]
		[Display(Name = "Usuario Creador")]
		public int IdUsuarioCreador { get; set; }
	}
}
