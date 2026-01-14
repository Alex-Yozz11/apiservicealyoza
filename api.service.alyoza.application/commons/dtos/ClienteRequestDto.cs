namespace api.service.alyoza.application.commons.dtos;

public sealed record ClienteRequestDto(
    string TipoIdentificacion,
    string Identificacion,
    string Nombre,
    string Apellido,
    string? Telefono,
    string Email
);