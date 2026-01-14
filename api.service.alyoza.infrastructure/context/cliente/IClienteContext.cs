using api.service.alyoza.domain.clases;

namespace api.service.alyoza.infrastructure.context.cliente;

public interface IClienteContext
{
    Task<List<Cliente>> GetAllAsync();
    Task<Cliente> GetByIdAsync(int id);
    Task<Cliente> InsertAsync(Cliente cliente);
    Task<(bool, string?)> UpdateAsync(Cliente cliente);
    Task<(bool, string?)> Delete(int id, bool softDelete);
}