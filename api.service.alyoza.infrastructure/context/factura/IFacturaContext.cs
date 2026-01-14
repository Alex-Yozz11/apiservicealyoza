using api.service.alyoza.domain.clases;

namespace api.service.alyoza.infrastructure.context.factura;

public interface IFacturaContext
{
    Task<List<Factura>> GetAllAsync();
    Task<Factura> GetByIdAsync(int id);
    Task<Factura> InsertAsync(Factura factura);
    Task<(bool, string?)> UpdateAsync(Factura factura);
    Task<(bool, string?)> Delete(int id, bool softDelete);
}