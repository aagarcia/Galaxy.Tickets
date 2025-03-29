namespace Galaxy.Tickets.Entidades;

public partial class Comentario : EntidadBase
{
    public int IdTicket { get; set; }

    public int IdUsuario { get; set; }

    public string Comentario1 { get; set; } = null!;

    public virtual Ticket IdTicketNavigation { get; set; } = null!;

    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
}
