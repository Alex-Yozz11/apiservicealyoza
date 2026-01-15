using Microsoft.EntityFrameworkCore;
using api.service.alyoza.domain.clases;

namespace api.service.alyoza.infrastructure.context;

public partial class AlyozaDbContext(DbContextOptions<AlyozaDbContext> options) : DbContext(options)
{
    
    public required DbSet<Cliente> Clientes { get; set; }
    public required DbSet<DetalleFactura> DetalleFacturas { get; set; }
    public required DbSet<Factura> Facturas { get; set; }
    public required DbSet<TipoVehiculo> TipoVehiculos { get; set; }
    public required DbSet<Vehiculo> Vehiculos { get; set; }
    public required DbSet<Vendedor> Vendedors { get; set; }

    
    private static readonly string[] _aalLevel = ["aal1", "aal2", "aal3"];
    private static readonly string[] _codeChallengeMethod = ["s256", "plain"];
    private static readonly string[] _factorStatus = ["unverified", "verified"];
    private static readonly string[] _factorType = ["totp", "webauthn", "phone"];
    private static readonly string[] _oauthAuthorizationStatus = ["pending", "approved", "denied", "expired"];
    private static readonly string[] _oauthClientType = ["public", "confidential"];
    private static readonly string[] _oauthRegistrationType = ["dynamic", "manual"];
    private static readonly string[] _oauthResponseType = ["code"];
    private static readonly string[] _oneTimeTokenType = [
        "confirmation_token", "reauthentication_token", "recovery_token",
        "email_change_token_new", "email_change_token_current", "phone_change_token"
    ];
    private static readonly string[] _action = ["INSERT", "UPDATE", "DELETE", "TRUNCATE", "ERROR"];
    private static readonly string[] _equalityOp = ["eq", "neq", "lt", "lte", "gt", "gte", "in"];
    private static readonly string[] _bucketType = ["STANDARD", "ANALYTICS", "VECTOR"];

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
        modelBuilder
            .HasPostgresEnum("auth", "aal_level", _aalLevel)
            .HasPostgresEnum("auth", "code_challenge_method", _codeChallengeMethod)
            .HasPostgresEnum("auth", "factor_status", _factorStatus)
            .HasPostgresEnum("auth", "factor_type", _factorType)
            .HasPostgresEnum("auth", "oauth_authorization_status", _oauthAuthorizationStatus)
            .HasPostgresEnum("auth", "oauth_client_type", _oauthClientType)
            .HasPostgresEnum("auth", "oauth_registration_type", _oauthRegistrationType)
            .HasPostgresEnum("auth", "oauth_response_type", _oauthResponseType)
            .HasPostgresEnum("auth", "one_time_token_type", _oneTimeTokenType)
            .HasPostgresEnum("realtime", "action", _action)
            .HasPostgresEnum("realtime", "equality_op", _equalityOp)
            .HasPostgresEnum("storage", "buckettype", _bucketType)
            .HasPostgresExtension("extensions", "pg_stat_statements")
            .HasPostgresExtension("extensions", "pgcrypto")
            .HasPostgresExtension("extensions", "uuid-ossp")
            .HasPostgresExtension("graphql", "pg_graphql")
            .HasPostgresExtension("vault", "supabase_vault");

        
        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.IdCliente).HasName("clientes_pkey");
            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.CreadoEn).HasDefaultValueSql("CURRENT_TIMESTAMP");
        });

        
        modelBuilder.Entity<DetalleFactura>(entity =>
        {
            entity.HasKey(e => e.IdDetalle).HasName("detalle_factura_pkey");
            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.CreadoEn).HasDefaultValueSql("CURRENT_TIMESTAMP");

            
            entity.Property(e => e.PrecioUnitario).HasPrecision(10, 2);
            entity.Property(e => e.SubtotalLinea).HasPrecision(10, 2);

            entity.HasOne(d => d.IdFacturaNavigation).WithMany(p => p.DetalleFacturas)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_detalle_factura");

            entity.HasOne(d => d.IdVehiculoNavigation).WithMany(p => p.DetalleFacturas)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_detalle_vehiculo");
        });

        
        modelBuilder.Entity<Factura>(entity =>
        {
            entity.HasKey(e => e.IdFactura).HasName("facturas_pkey");
            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.CreadoEn).HasDefaultValueSql("CURRENT_TIMESTAMP");
            entity.Property(e => e.Estado).HasDefaultValueSql("'PENDIENTE'::character varying");
            entity.Property(e => e.Fecha).HasDefaultValueSql("CURRENT_TIMESTAMP");
            entity.Property(e => e.Impuesto).HasDefaultValueSql("0");

            
            entity.Property(e => e.Subtotal).HasPrecision(10, 2);
            entity.Property(e => e.Impuesto).HasPrecision(10, 2);
            entity.Property(e => e.Total).HasPrecision(10, 2);

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.Facturas)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_factura_cliente");

            entity.HasOne(d => d.IdVendedorNavigation).WithMany(p => p.Facturas)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_factura_vendedor");
        });

        
        modelBuilder.Entity<TipoVehiculo>(entity =>
        {
            entity.HasKey(e => e.IdTipoVehiculo).HasName("tipo_vehiculos_pkey");
            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.CreadoEn).HasDefaultValueSql("CURRENT_TIMESTAMP");
        });

        
        modelBuilder.Entity<Vehiculo>(entity =>
        {
            entity.HasKey(e => e.IdVehiculo).HasName("vehiculos_pkey");
            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.CreadoEn).HasDefaultValueSql("CURRENT_TIMESTAMP");

            
            entity.Property(e => e.Precio).HasPrecision(10, 2);

            entity.HasOne(d => d.IdTipoVehiculoNavigation).WithMany(p => p.Vehiculos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_vehiculo_tipo");
        });

        
        modelBuilder.Entity<Vendedor>(entity =>
        {
            entity.HasKey(e => e.IdVendedor).HasName("vendedores_pkey");
            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.CreadoEn).HasDefaultValueSql("CURRENT_TIMESTAMP");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}