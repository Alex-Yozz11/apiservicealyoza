using api.service.alyoza.infrastructure.context;
using api.service.alyoza.infrastructure.context.cliente;
using api.service.alyoza.infrastructure.context.factura;
using api.service.alyoza.infrastructure.context.detallefactura;
using api.service.alyoza.infrastructure.context.vehiculo;
using api.service.alyoza.infrastructure.context.tipovehiculo;
using api.service.alyoza.infrastructure.context.vendedor;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace api.service.alyoza.infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(this IServiceCollection services,
                                                    IConfiguration configuration)
    {
        services.AddDbContext<AlyozaDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"),
                              builder => builder.MigrationsAssembly(typeof(AlyozaDbContext).Assembly.FullName)
                                                .EnableRetryOnFailure(
                                                    maxRetryCount: 5,
                                                    maxRetryDelay: TimeSpan.FromSeconds(10),
                                                    errorCodesToAdd: null
                                                ))
        );

        // Contexto genérico
        services.AddScoped(typeof(IContextGeneral<>), typeof(ContextGeneral<>));

        // Contextos específicos por entidad
        services.AddScoped<IClienteContext, ClienteContext>();
        services.AddScoped<IFacturaContext, FacturaContext>();
        services.AddScoped<IDetalleFacturaContext, DetalleFacturaContext>();
        services.AddScoped<IVehiculoContext, VehiculoContext>();
        services.AddScoped<ITipoVehiculoContext, TipoVehiculoContext>();
        services.AddScoped<IVendedorContext, VendedorContext>();

        return services;
    }
}