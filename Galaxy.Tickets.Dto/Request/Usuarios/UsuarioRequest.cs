using Galaxy.Tickets.Comun;
using System.ComponentModel.DataAnnotations;

namespace Galaxy.Tickets.Dto.Request.Usuarios
{
	public class UsuarioRequest
	{
		[Required(ErrorMessage = Constantes.MensajeRequired)]
		[Display(Name = "Nombre")]
		public string Nombre { get; set; } = null!;

		[Required(ErrorMessage = Constantes.MensajeRequired)]
		[EmailAddress(ErrorMessage = Constantes.MensajeEmail)]
		[Display(Name = "Email")]
		public string Email { get; set; } = null!;

		[Required(ErrorMessage = Constantes.MensajeRequired)]
		[Display(Name = "Contraseña")]
		public string Contraseña { get; set; } = null!;

		[Required(ErrorMessage = Constantes.MensajeRequired)]
		[DeniedValues(0, ErrorMessage = Constantes.MensajeRequired)]
		[Display(Name = "Rol")]
		public int IdRol { get; set; }
	}
}
