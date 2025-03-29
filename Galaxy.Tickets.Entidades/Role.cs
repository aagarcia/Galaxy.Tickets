namespace Galaxy.Tickets.Entidades;

public partial class Role : EntidadBase
{
    public string Nombre { get; set; } = null!;
    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
