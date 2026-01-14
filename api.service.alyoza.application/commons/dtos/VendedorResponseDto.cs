namespace api.service.alyoza.application.commons.dtos;

public sealed record VendedorResponseDto(
    int IdVendedor,
    string Nombre,
    string? Telefono,
    bool? Activo,
    DateTime? CreadoEn,
    DateTime? ActualizadoEn
);