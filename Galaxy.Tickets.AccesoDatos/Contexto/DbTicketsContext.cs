using Galaxy.Tickets.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Galaxy.Tickets.AccesoDatos.Contexto;

public partial class DbTicketsContext : DbContext
{
    public DbTicketsContext()
    {
    }

    public DbTicketsContext(DbContextOptions<DbTicketsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Categoria> Categorias { get; set; }

    public virtual DbSet<Comentario> Comentarios { get; set; }

    public virtual DbSet<Estado> Estados { get; set; }

    public virtual DbSet<Prioridade> Prioridades { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Ticket> Tickets { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Categoria>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Categori__3214EC07FE348725");

            entity.Property(e => e.Estado).HasDefaultValue(true);
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.Nombre).HasMaxLength(100);
        });

        modelBuilder.Entity<Comentario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Comentar__3214EC0735269C27");

            entity.Property(e => e.Comentario1)
                .HasColumnType("text")
                .HasColumnName("Comentario");
            entity.Property(e => e.Estado).HasDefaultValue(true);
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");

            entity.HasOne(d => d.IdTicketNavigation).WithMany(p => p.Comentarios)
                .HasForeignKey(d => d.IdTicket)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Comentarios_Ticket");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Comentarios)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Comentarios_Usuario");
        });

        modelBuilder.Entity<Estado>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Estados__3214EC07C0D48FAC");

            entity.HasIndex(e => e.Nombre, "UQ__Estados__75E3EFCFCA2B269E").IsUnique();

            entity.Property(e => e.Estado)
                .HasDefaultValue(true)
                .HasColumnName("Estado");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.Nombre).HasMaxLength(50);
        });

        modelBuilder.Entity<Prioridade>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Priorida__3214EC076998261C");

            entity.HasIndex(e => e.Nombre, "UQ__Priorida__75E3EFCF733F01B5").IsUnique();

            entity.Property(e => e.Estado).HasDefaultValue(true);
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.Nombre).HasMaxLength(50);
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Roles__3214EC07CBDA022D");

            entity.HasIndex(e => e.Nombre, "UQ__Roles__75E3EFCF2CA87768").IsUnique();

            entity.Property(e => e.Estado).HasDefaultValue(true);
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.Nombre).HasMaxLength(50);
        });

        modelBuilder.Entity<Ticket>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Tickets__3214EC072189EA89");

            entity.Property(e => e.Descripcion).HasColumnType("text");
            entity.Property(e => e.Estado).HasDefaultValue(true);
            entity.Property(e => e.FechaCierre).HasColumnType("datetime");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.IdEstado).HasDefaultValue(1);
            entity.Property(e => e.Titulo).HasMaxLength(255);

            entity.HasOne(d => d.IdCategoriaNavigation).WithMany(p => p.Tickets)
                .HasForeignKey(d => d.IdCategoria)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Tickets_Categoria");

            entity.HasOne(d => d.IdEstadoNavigation).WithMany(p => p.Tickets)
                .HasForeignKey(d => d.IdEstado)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Tickets_Estado");

            entity.HasOne(d => d.IdPrioridadNavigation).WithMany(p => p.Tickets)
                .HasForeignKey(d => d.IdPrioridad)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Tickets_Prioridad");

            entity.HasOne(d => d.IdUsuarioAsignadoNavigation).WithMany(p => p.TicketIdUsuarioAsignadoNavigations)
                .HasForeignKey(d => d.IdUsuarioAsignado)
                .HasConstraintName("FK_Tickets_UsuarioAsignado");

            entity.HasOne(d => d.IdUsuarioCreadorNavigation).WithMany(p => p.TicketIdUsuarioCreadorNavigations)
                .HasForeignKey(d => d.IdUsuarioCreador)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Tickets_UsuarioCreador");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Usuarios__3214EC07CF006607");

            entity.HasIndex(e => e.Email, "UQ__Usuarios__A9D10534E5CF1328").IsUnique();

            entity.Property(e => e.Contraseña).HasMaxLength(255);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Estado).HasDefaultValue(true);
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.Nombre).HasMaxLength(100);

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdRol)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Usuarios_Rol");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
