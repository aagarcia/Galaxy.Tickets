using Galaxy.Tickets.Comun;
using System.ComponentModel.DataAnnotations;

namespace Galaxy.Tickets.Dto.Request.Prioridades
{
	public class PrioridadRequest
	{
		[Required(ErrorMessage = Constantes.MensajeRequired)]
		[Display(Name = "Nombre")]
		public string Nombre { get; set; } = null!;
	}
}
