namespace api.service.ayoza.application.commons.dtos;

public sealed record VendedorRequestDto(
    string Nombre,
    string? Telefono
);