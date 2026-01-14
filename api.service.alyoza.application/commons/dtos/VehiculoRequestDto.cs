namespace api.service.alyoza.application.commons.dtos;

public sealed record VehiculoRequestDto(
    string Marca,
    string Modelo,
    int? Anio,
    decimal Precio,
    int IdTipoVehiculo
);