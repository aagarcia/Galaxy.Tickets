namespace Galaxy.Tickets.Entidades;

public partial class Usuario : EntidadBase
{
    public string Nombre { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Contraseña { get; set; } = null!;

    public int IdRol { get; set; }

    public virtual ICollection<Comentario> Comentarios { get; set; } = new List<Comentario>();

    public virtual Role IdRolNavigation { get; set; } = null!;

    public virtual ICollection<Ticket> TicketIdUsuarioAsignadoNavigations { get; set; } = new List<Ticket>();

    public virtual ICollection<Ticket> TicketIdUsuarioCreadorNavigations { get; set; } = new List<Ticket>();
}
