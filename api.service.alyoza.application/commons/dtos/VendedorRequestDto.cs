namespace api.service.alyoza.application.commons.dtos;

public sealed record VendedorRequestDto(
    string Nombre,
    string? Telefono
);