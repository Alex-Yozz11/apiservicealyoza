namespace api.service.ayoza.application.commons.dtos;

public sealed record TipoVehiculoRequestDto(
    string Nombre,
    string? Descripcion
);