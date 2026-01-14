using api.service.alyoza.application.commons.dtos;

namespace api.service.alyoza.application.ifeatures;

public interface IFacturaHandler
{
    Task<List<FacturaResponseDto>> GetAll();
    Task<FacturaResponseDto> GetById(int id);
    Task<FacturaResponseDto> Insert(FacturaRequestDto facturaRequest);
    Task<(bool, string?)> UpdateAsync(FacturaRequestDto facturaRequest, int id);
    Task<(bool, string?)> Delete(int id, bool softDelete);
}