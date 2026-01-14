using api.service.ayoza.application.commons.dtos;

namespace api.service.ayoza.application.ifeatures;

public interface IDetalleFacturaHandler
{
    Task<List<DetalleFacturaResponseDto>> GetAll();
    Task<DetalleFacturaResponseDto> GetById(int id);
    Task<DetalleFacturaResponseDto> Insert(DetalleFacturaRequestDto detalleFacturaRequest);
    Task<(bool, string?)> UpdateAsync(DetalleFacturaRequestDto detalleFacturaRequest, int id);
    Task<(bool, string?)> Delete(int id, bool softDelete);
}