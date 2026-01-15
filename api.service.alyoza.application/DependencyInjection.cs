using api.service.alyoza.application.commons.mappings;
using api.service.alyoza.application.features;
using api.service.alyoza.application.ifeatures;
using Microsoft.Extensions.DependencyInjection;

namespace api.service.alyoza.application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        // Registrar la clase Mappings para que pueda inyectarse en los Handlers
        services.AddSingleton<Mappings>();

        // Registrar Handlers
        services.AddScoped<IClienteHandler, ClienteHandler>();
        services.AddScoped<IFacturaHandler, FacturaHandler>();
        services.AddScoped<IVehiculoHandler, VehiculoHandler>();
        services.AddScoped<IVendedorHandler, VendedorHandler>();
        services.AddScoped<ITipoVehiculoHandler, TipoVehiculoHandler>();
        services.AddScoped<IDetalleFacturaHandler, DetalleFacturaHandler>();

        return services;
    }
}