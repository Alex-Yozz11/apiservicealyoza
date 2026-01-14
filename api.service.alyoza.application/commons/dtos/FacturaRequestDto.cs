namespace api.service.ayoza.application.commons.dtos;

public sealed record FacturaRequestDto(
    int IdCliente,
    int IdVendedor,
    DateTime? Fecha,
    string? Estado,
    decimal Subtotal,
    decimal? Impuesto,
    decimal Total,
    List<DetalleFacturaRequestDto> DetalleFacturas
);