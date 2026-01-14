using api.service.ayoza.application.features;
using api.service.ayoza.application.ifeatures;
using Microsoft.Extensions.DependencyInjection;

namespace api.service.ayoza.application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        // Handlers
        services.AddScoped<IClienteHandler, ClienteHandler>();
        services.AddScoped<IFacturaHandler, FacturaHandler>();
        services.AddScoped<IVehiculoHandler, VehiculoHandler>();
        services.AddScoped<IVendedorHandler, VendedorHandler>();
        services.AddScoped<ITipoVehiculoHandler, TipoVehiculoHandler>();
        services.AddScoped<IDetalleFacturaHandler, DetalleFacturaHandler>();

        return services;
    }
}