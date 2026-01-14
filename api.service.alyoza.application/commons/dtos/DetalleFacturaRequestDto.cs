namespace api.service.ayoza.application.commons.dtos;

public sealed record DetalleFacturaRequestDto(
    int IdFactura,
    int IdVehiculo,
    int Cantidad,
    decimal PrecioUnitario
);