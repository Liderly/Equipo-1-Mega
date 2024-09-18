using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace backend.Models;

public partial class DbHackathonMegaContext : DbContext
{
    public DbHackathonMegaContext()
    {
    }

    public DbHackathonMegaContext(DbContextOptions<DbHackathonMegaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cuadrilla> Cuadrillas { get; set; }

    public virtual DbSet<Empleado> Empleados { get; set; }

    public virtual DbSet<Estatus> Estatuses { get; set; }

    public virtual DbSet<OrdenTrabajo> OrdenTrabajos { get; set; }

    public virtual DbSet<Servicio> Servicios { get; set; }

    public virtual DbSet<Suscriptor> Suscriptors { get; set; }

    public virtual DbSet<Trabajo> Trabajos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=LAPTOPS1;Database=DbHackathonMega;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cuadrilla>(entity =>
        {
            entity.HasKey(e => e.Idcuadrilla).HasName("PK__Cuadrill__9FEDFEB55677D5CA");

            entity.ToTable("Cuadrilla");

            entity.Property(e => e.Idcuadrilla).HasColumnName("IDCuadrilla");
        });

        modelBuilder.Entity<Empleado>(entity =>
        {
            entity.HasKey(e => e.Idempleado).HasName("PK__Empleado__50621DCD0C36DFE1");

            entity.ToTable("Empleado");

            entity.Property(e => e.Idempleado).HasColumnName("IDEmpleado");
            entity.Property(e => e.Apellido).HasMaxLength(150);
            entity.Property(e => e.Idcuadrilla).HasColumnName("IDCuadrilla");
            entity.Property(e => e.Nombre).HasMaxLength(150);

            entity.HasOne(d => d.IdcuadrillaNavigation).WithMany(p => p.Empleados)
                .HasForeignKey(d => d.Idcuadrilla)
                .HasConstraintName("FK__Empleado__IDCuad__3B75D760");
        });

        modelBuilder.Entity<Estatus>(entity =>
        {
            entity.HasKey(e => e.Idestatus).HasName("PK__Estatus__042C4B5168E2B54A");

            entity.ToTable("Estatus");

            entity.Property(e => e.Idestatus).HasColumnName("IDEstatus");
            entity.Property(e => e.Nombre).HasMaxLength(30);
        });

        modelBuilder.Entity<OrdenTrabajo>(entity =>
        {
            entity.HasKey(e => e.Idorden).HasName("PK__OrdenTra__5CBBCAD79A63ECA3");

            entity.ToTable("OrdenTrabajo");

            entity.Property(e => e.Idorden).HasColumnName("IDOrden");
            entity.Property(e => e.FechaCreación)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Idempleado).HasColumnName("IDEmpleado");
            entity.Property(e => e.Idestatus).HasColumnName("IDEstatus");
            entity.Property(e => e.Idservicio).HasColumnName("IDServicio");
            entity.Property(e => e.Idsuscriptor).HasColumnName("IDSuscriptor");
            entity.Property(e => e.Idtrabajo).HasColumnName("IDTrabajo");

            entity.HasOne(d => d.IdempleadoNavigation).WithMany(p => p.OrdenTrabajos)
                .HasForeignKey(d => d.Idempleado)
                .HasConstraintName("FK__OrdenTrab__IDEmp__45F365D3");

            entity.HasOne(d => d.IdestatusNavigation).WithMany(p => p.OrdenTrabajos)
                .HasForeignKey(d => d.Idestatus)
                .HasConstraintName("FK__OrdenTrab__IDEst__48CFD27E");

            entity.HasOne(d => d.IdservicioNavigation).WithMany(p => p.OrdenTrabajos)
                .HasForeignKey(d => d.Idservicio)
                .HasConstraintName("FK__OrdenTrab__IDSer__47DBAE45");

            entity.HasOne(d => d.IdsuscriptorNavigation).WithMany(p => p.OrdenTrabajos)
                .HasForeignKey(d => d.Idsuscriptor)
                .HasConstraintName("FK__OrdenTrab__IDSus__44FF419A");

            entity.HasOne(d => d.IdtrabajoNavigation).WithMany(p => p.OrdenTrabajos)
                .HasForeignKey(d => d.Idtrabajo)
                .HasConstraintName("FK__OrdenTrab__IDTra__46E78A0C");
        });

        modelBuilder.Entity<Servicio>(entity =>
        {
            entity.HasKey(e => e.Idservicio).HasName("PK__Servicio__3CCE7416B6DB45C2");

            entity.ToTable("Servicio");

            entity.Property(e => e.Idservicio).HasColumnName("IDServicio");
            entity.Property(e => e.Descripcion).HasMaxLength(40);
        });

        modelBuilder.Entity<Suscriptor>(entity =>
        {
            entity.HasKey(e => e.Idsuscriptor).HasName("PK__Suscript__522CB8BFDCFD64F4");

            entity.ToTable("Suscriptor");

            entity.Property(e => e.Idsuscriptor).HasColumnName("IDSuscriptor");
            entity.Property(e => e.Apellido).HasMaxLength(150);
            entity.Property(e => e.Correo).HasMaxLength(80);
            entity.Property(e => e.Domicilio).HasMaxLength(120);
            entity.Property(e => e.Nombre).HasMaxLength(150);
        });

        modelBuilder.Entity<Trabajo>(entity =>
        {
            entity.HasKey(e => e.Idtrabajo).HasName("PK__Trabajos__6892899D5EBBC326");

            entity.Property(e => e.Idtrabajo).HasColumnName("IDTrabajo");
            entity.Property(e => e.Descripcion).HasMaxLength(80);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
