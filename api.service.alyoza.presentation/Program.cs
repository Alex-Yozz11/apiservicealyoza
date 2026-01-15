using api.service.alyoza.infrastructure;
using api.service.alyoza.application;
using api.service.alyoza.presentation.endpoint;

var builder = WebApplication.CreateBuilder(args);

var port = Environment.GetEnvironmentVariable("PORT") ?? "3000";
var url = $"http://0.0.0.0:{port}";

#region servicios
// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddPersistence(builder.Configuration);
builder.Services.AddApplicationServices();
#endregion servicios

var app = builder.Build();

#region middleware
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Endpoints agrupados por entidad
app.MapGroup("/v1/cliente").MapCliente();
app.MapGroup("/v1/factura").MapFactura();
app.MapGroup("/v1/detallefactura").MapDetalleFactura();
app.MapGroup("/v1/vehiculo").MapVehiculo();
app.MapGroup("/v1/tipovehiculo").MapTipoVehiculo();
app.MapGroup("/v1/vendedor").MapVendedor();
#endregion middleware

app.Run(url);