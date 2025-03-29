using Galaxy.Tickets.Comun;
using System.ComponentModel.DataAnnotations;

namespace Galaxy.Tickets.Dto.Request.Estados
{
	public class EstadoRequest
	{
		[Required(ErrorMessage = Constantes.MensajeRequired)]
		[Display(Name = "Nombre")]
		public string Nombre { get; set; } = null!;
	}
}
