namespace Galaxy.Tickets.Entidades;

public partial class Ticket : EntidadBase
{
    public string Titulo { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public int? IdUsuarioAsignado { get; set; }

    public int IdCategoria { get; set; }

    public int IdPrioridad { get; set; }

    public int IdEstado { get; set; }

    public DateTime? FechaCierre { get; set; }

    public virtual ICollection<Comentario> Comentarios { get; set; } = new List<Comentario>();

    public virtual Categoria IdCategoriaNavigation { get; set; } = null!;

    public virtual Estado IdEstadoNavigation { get; set; } = null!;

    public virtual Prioridade IdPrioridadNavigation { get; set; } = null!;

    public virtual Usuario? IdUsuarioAsignadoNavigation { get; set; }

    public virtual Usuario IdUsuarioCreadorNavigation { get; set; } = null!;
}
