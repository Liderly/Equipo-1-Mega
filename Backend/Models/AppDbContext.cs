using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Backend_HackathonMega.Models;

public partial class AppDBContext : DbContext
{
    private readonly IConfiguration _configuration;
    
    public AppDBContext(DbContextOptions<AppDBContext> options, IConfiguration configuration)
        : base(options)
    {
        _configuration = configuration;
    }
    
    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Cuadrilla> Cuadrillas { get; set; }

    public virtual DbSet<Estatus> Estatuses { get; set; }

    public virtual DbSet<OrdenesTrabajo> OrdenesTrabajos { get; set; }

    public virtual DbSet<PagoPunto> PagoPuntos { get; set; }

    public virtual DbSet<PuntosTrabajo> PuntosTrabajos { get; set; }

    public virtual DbSet<RangoPunto> RangoPuntos { get; set; }

    public virtual DbSet<Servicio> Servicios { get; set; }

    public virtual DbSet<TecnicoInstalador> TecnicoInstaladors { get; set; }

    public virtual DbSet<Trabajo> Trabajos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
    if (!optionsBuilder.IsConfigured)
    {
        var connectionString = _configuration.GetConnectionString("DefaultConnection");
        optionsBuilder.UseSqlServer(connectionString);
    }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PuntosCuadrilla>(entity =>
        {
            entity.HasNoKey(); // Esto es importante si no tiene clave primaria
            // Configuraciones adicionales si es necesario
        });

        modelBuilder.Entity<PuntosTecnico>(entity =>
        {
            entity.HasNoKey(); // Esto es importante si no tiene clave primaria
            // Configuraciones adicionales si es necesario
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.ClienteId).HasName("PK__Clientes__71ABD0A7A86190EE");

            entity.Property(e => e.ClienteId).HasColumnName("ClienteID");
            entity.Property(e => e.Apellido).HasMaxLength(30);
            entity.Property(e => e.Domicilio).HasMaxLength(50);
            entity.Property(e => e.Nombre).HasMaxLength(30);
            entity.Property(e => e.Telefono).HasMaxLength(20);
        });

        modelBuilder.Entity<Cuadrilla>(entity =>
        {
            entity.HasKey(e => e.CuadrillaId).HasName("PK__Cuadrill__C1B110D119FC9598");

            entity.ToTable("Cuadrilla");

            entity.Property(e => e.CuadrillaId).HasColumnName("CuadrillaID");
        });

        modelBuilder.Entity<Estatus>(entity =>
        {
            entity.HasKey(e => e.EstatusId).HasName("PK__Estatus__DE10F26D3AF4804D");

            entity.ToTable("Estatus");

            entity.Property(e => e.EstatusId).HasColumnName("EstatusID");
            entity.Property(e => e.Nombre).HasMaxLength(30);
        });

        modelBuilder.Entity<OrdenesTrabajo>(entity =>
        {
            entity.HasKey(e => e.OrdenTrabajoId).HasName("PK__OrdenesT__A8444C1D5B8308C6");

            entity.ToTable("OrdenesTrabajo");

            entity.Property(e => e.OrdenTrabajoId).HasColumnName("OrdenTrabajoID");
            entity.Property(e => e.ClienteId).HasColumnName("ClienteID");
            entity.Property(e => e.CuadrillaId).HasColumnName("CuadrillaID");
            entity.Property(e => e.EstatusId).HasColumnName("EstatusID");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaFinalizacion).HasColumnType("datetime");
            entity.Property(e => e.ServicioId).HasColumnName("ServicioID");
            entity.Property(e => e.TrabajoId).HasColumnName("TrabajoID");

            entity.HasOne(d => d.Cliente).WithMany(p => p.OrdenesTrabajos)
                .HasForeignKey(d => d.ClienteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__OrdenesTr__Clien__25518C17");

            entity.HasOne(d => d.Cuadrilla).WithMany(p => p.OrdenesTrabajos)
                .HasForeignKey(d => d.CuadrillaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__OrdenesTr__Cuadr__2739D489");

            entity.HasOne(d => d.Estatus).WithMany(p => p.OrdenesTrabajos)
                .HasForeignKey(d => d.EstatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__OrdenesTr__Estat__282DF8C2");

            entity.HasOne(d => d.Servicio).WithMany(p => p.OrdenesTrabajos)
                .HasForeignKey(d => d.ServicioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__OrdenesTr__Servi__29221CFB");

            entity.HasOne(d => d.Trabajo).WithMany(p => p.OrdenesTrabajos)
                .HasForeignKey(d => d.TrabajoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__OrdenesTr__Traba__2645B050");
        });

        modelBuilder.Entity<PagoPunto>(entity =>
        {
            entity.HasKey(e => e.PagoPuntosId).HasName("PK__PagoPunt__442DE3829103DA23");

            entity.Property(e => e.PagoPuntosId).HasColumnName("PagoPuntosID");
        });

        modelBuilder.Entity<PuntosTrabajo>(entity =>
        {
            entity.HasKey(e => e.PuntosTrabajoId).HasName("PK__PuntosTr__42263547B75141A6");

            entity.ToTable("PuntosTrabajo");

            entity.Property(e => e.PuntosTrabajoId).HasColumnName("PuntosTrabajoID");
        });

        modelBuilder.Entity<RangoPunto>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.PagoPuntosId).HasColumnName("PagoPuntosID");

            entity.HasOne(d => d.PagoPuntos).WithMany()
                .HasForeignKey(d => d.PagoPuntosId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__RangoPunt__PagoP__04E4BC85");
        });

        modelBuilder.Entity<Servicio>(entity =>
        {
            entity.HasKey(e => e.ServicioId).HasName("PK__Servicio__D5AEEC2211492830");

            entity.Property(e => e.ServicioId).HasColumnName("ServicioID");
            entity.Property(e => e.NombreServicio).HasMaxLength(30);
        });

        modelBuilder.Entity<TecnicoInstalador>(entity =>
        {
            entity.HasKey(e => e.TecnicoInstaladorId).HasName("PK__TecnicoI__5B1E2B2628AFDC95");

            entity.ToTable("TecnicoInstalador");

            entity.Property(e => e.TecnicoInstaladorId).HasColumnName("TecnicoInstaladorID");
            entity.Property(e => e.Apellido).HasMaxLength(30);
            entity.Property(e => e.CuadrillaId).HasColumnName("CuadrillaID");
            entity.Property(e => e.Nombre).HasMaxLength(30);
            entity.Property(e => e.NumTecnico).HasMaxLength(20);

            entity.HasOne(d => d.Cuadrilla).WithMany(p => p.TecnicoInstaladors)
                .HasForeignKey(d => d.CuadrillaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__TecnicoIn__Cuadr__73BA3083");
        });

        modelBuilder.Entity<Trabajo>(entity =>
        {
            entity.HasKey(e => e.TrabajoId).HasName("PK__Trabajos__FCD3CD5E290B7302");

            entity.Property(e => e.TrabajoId).HasColumnName("TrabajoID");
            entity.Property(e => e.Descripcion).HasMaxLength(50);
            entity.Property(e => e.PuntosTrabajoId).HasColumnName("PuntosTrabajoID");

            entity.HasOne(d => d.PuntosTrabajo).WithMany(p => p.Trabajos)
                .HasForeignKey(d => d.PuntosTrabajoId)
                .HasConstraintName("FK__Trabajos__Puntos__7A672E12");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}