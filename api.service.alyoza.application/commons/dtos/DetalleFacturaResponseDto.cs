namespace api.service.alyoza.application.commons.dtos;

public sealed record DetalleFacturaResponseDto(
    int IdDetalle,
    int IdFactura,
    int IdVehiculo,
    int Cantidad,
    decimal PrecioUnitario,
    decimal SubtotalLinea,
    bool? Activo,
    DateTime? CreadoEn,
    DateTime? ActualizadoEn
);