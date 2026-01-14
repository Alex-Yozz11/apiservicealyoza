using api.service.alyoza.application.commons.dtos;

namespace api.service.alyoza.application.ifeatures;

public interface IVehiculoHandler
{
    Task<List<VehiculoResponseDto>> GetAll();
    Task<VehiculoResponseDto> GetById(int id);
    Task<VehiculoResponseDto> Insert(VehiculoRequestDto vehiculoRequest);
    Task<(bool, string?)> UpdateAsync(VehiculoRequestDto vehiculoRequest, int id);
    Task<(bool, string?)> Delete(int id, bool softDelete);
}