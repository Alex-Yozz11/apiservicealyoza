using api.service.alyoza.domain.clases;

namespace api.service.alyoza.infrastructure.context.vehiculo;

public interface IVehiculoContext
{
    Task<List<Vehiculo>> GetAllAsync();
    Task<Vehiculo> GetByIdAsync(int id);
    Task<Vehiculo> InsertAsync(Vehiculo vehiculo);
    Task<(bool, string?)> UpdateAsync(Vehiculo vehiculo);
    Task<(bool, string?)> Delete(int id, bool softDelete);
}