namespace api.service.alyoza.application.commons.dtos;

public sealed record DetalleFacturaRequestDto(
    int IdFactura,
    int IdVehiculo,
    int Cantidad,
    decimal PrecioUnitario
);