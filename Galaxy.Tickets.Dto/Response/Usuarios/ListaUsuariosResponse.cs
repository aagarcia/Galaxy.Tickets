namespace Galaxy.Tickets.Dto.Response.Usuarios
{
	public class ListaUsuariosResponse
	{
		public int Id { get; set; }
		public string Nombre { get; set; } = null!;

		public string Email { get; set; } = null!;

		public string Rol { get; set; } = null!;
	}
}
