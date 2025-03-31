namespace Galaxy.Tickets.Dto.Request.Usuarios
{
	public class BusquedaUsuariosRequest : PaginacionRequest
	{
		public string Nombre { get; set; } = null!;

		public string Email { get; set; } = null!;

		public int IdRol { get; set; }
	}
}
