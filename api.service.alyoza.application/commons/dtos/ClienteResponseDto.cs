namespace api.service.alyoza.application.commons.dtos;

public sealed record ClienteResponseDto(
    int IdCliente,
    string TipoIdentificacion,
    string Identificacion,
    string Nombre,
    string Apellido,
    string? Telefono,
    string Email,
    bool? Activo,
    DateTime? CreadoEn,
    DateTime? ActualizadoEn
);