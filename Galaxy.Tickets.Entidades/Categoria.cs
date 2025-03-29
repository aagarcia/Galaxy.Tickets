namespace Galaxy.Tickets.Entidades;

public partial class Categoria : EntidadBase
{
    public string Nombre { get; set; } = null!;

    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
}
