namespace api.service.ayoza.application.commons.dtos;

public sealed record VehiculoResponseDto(
    int IdVehiculo,
    string Marca,
    string Modelo,
    int? Anio,
    decimal Precio,
    int IdTipoVehiculo,
    bool? Activo,
    DateTime? CreadoEn,
    DateTime? ActualizadoEn
);