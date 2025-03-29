using Galaxy.Tickets.Comun;
using System.ComponentModel.DataAnnotations;

namespace Galaxy.Tickets.Dto.Request.Categorias
{
	public class CategoriaRequest
	{
		[Required(ErrorMessage = Constantes.MensajeRequired)]
		[Display(Name = "Nombre")]
		public string Nombre { get; set; } = null!;
	}
}
