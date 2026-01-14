namespace api.service.alyoza.application.commons.dtos;

public sealed record TipoVehiculoRequestDto(
    string Nombre,
    string? Descripcion
);