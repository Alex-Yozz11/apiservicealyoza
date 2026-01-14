using api.service.alyoza.domain.clases;

namespace api.service.alyoza.infrastructure.context.cliente;

public class ClienteContext : IClienteContext
{
    private readonly IContextGeneral<Cliente> _context;

    public ClienteContext(IContextGeneral<Cliente> context)
    {
        _context = context;
    }

    public async Task<List<Cliente>> GetAllAsync()
    {
        return await _context.GetAll();
    }

    public async Task<Cliente> GetByIdAsync(int id)
    {
        Cliente cliente = await _context.GetById(id) ?? new Cliente();
        return cliente;
    }

    public async Task<Cliente> InsertAsync(Cliente cliente)
    {
        cliente.CreadoEn = DateTime.Now;
        cliente.Activo = true;
        return await _context.Add(cliente);
    }

    public async Task<(bool, string?)> UpdateAsync(Cliente cliente)
    {
        bool isUpdate = false;
        var result = await _context.GetById(cliente.IdCliente);

        if (result != null)
        {
            if (!string.IsNullOrEmpty(cliente.Nombre) && cliente.Nombre != result.Nombre)
            {
                result.Nombre = cliente.Nombre;
                isUpdate = true;
            }

            if (!string.IsNullOrEmpty(cliente.Apellido) && cliente.Apellido != result.Apellido)
            {
                result.Apellido = cliente.Apellido;
                isUpdate = true;
            }

            if (!string.IsNullOrEmpty(cliente.Telefono) && cliente.Telefono != result.Telefono)
            {
                result.Telefono = cliente.Telefono;
                isUpdate = true;
            }

            if (!string.IsNullOrEmpty(cliente.Email) && cliente.Email != result.Email)
            {
                result.Email = cliente.Email;
                isUpdate = true;
            }

            if (!string.IsNullOrEmpty(cliente.Identificacion) && cliente.Identificacion != result.Identificacion)
            {
                result.Identificacion = cliente.Identificacion;
                isUpdate = true;
            }

            if (!string.IsNullOrEmpty(cliente.TipoIdentificacion) && cliente.TipoIdentificacion != result.TipoIdentificacion)
            {
                result.TipoIdentificacion = cliente.TipoIdentificacion;
                isUpdate = true;
            }

            if (isUpdate)
            {
                result.ActualizadoEn = DateTime.Now;
                await _context.Update(result);
                return (true, null);
            }
            else
            {
                return (false, null);
            }
        }

        return (false, "Cliente no encontrado");
    }

    public async Task<(bool, string?)> Delete(int id, bool softDelete)
    {
        var result = await _context.GetById(id);

        if (result != null)
        {
            result.Activo = !softDelete ? result.Activo : false;
            result.ActualizadoEn = DateTime.Now;
            await _context.Update(result);
            return (true, null);
        }

        return (false, "Cliente no encontrado");
    }
}