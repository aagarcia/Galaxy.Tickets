namespace Galaxy.Tickets.Dto.Response.Usuarios
{
	public class UsuarioResponse
	{
		public int Id { get; set; }
		public string Nombre { get; set; } = null!;

		public string Email { get; set; } = null!;

		public string Contraseña { get; set; } = null!;

		public int IdRol { get; set; }
	}
}
