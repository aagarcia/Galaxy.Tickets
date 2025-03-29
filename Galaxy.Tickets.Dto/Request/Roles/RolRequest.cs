using Galaxy.Tickets.Comun;
using System.ComponentModel.DataAnnotations;

namespace Galaxy.Tickets.Dto.Request.Roles
{
	public class RolRequest
	{
		[Required(ErrorMessage = Constantes.MensajeRequired)]
		[Display(Name = "Nombre")]
		public string Nombre { get; set; } = null!;
	}
}
