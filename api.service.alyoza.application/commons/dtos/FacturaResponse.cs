namespace api.service.ayoza.application.commons.dtos;

public sealed record FacturaResponseDto(
    int IdFactura,
    int IdCliente,
    int IdVendedor,
    DateTime? Fecha,
    string? Estado,
    decimal Subtotal,
    decimal? Impuesto,
    decimal Total,
    bool? Activo,
    DateTime? CreadoEn,
    DateTime? ActualizadoEn,
    List<DetalleFacturaResponseDto> DetalleFacturas
);