using api.service.ayoza.application.commons.dtos;

namespace api.service.ayoza.application.ifeatures;

public interface ITipoVehiculoHandler
{
    Task<List<TipoVehiculoResponseDto>> GetAll();
    Task<TipoVehiculoResponseDto> GetById(int id);
    Task<TipoVehiculoResponseDto> Insert(TipoVehiculoRequestDto tipoVehiculoRequest);
    Task<(bool, string?)> UpdateAsync(TipoVehiculoRequestDto tipoVehiculoRequest, int id);
    Task<(bool, string?)> Delete(int id, bool softDelete);
}