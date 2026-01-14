using api.service.alyoza.domain.clases;

namespace api.service.alyoza.infrastructure.context.vendedor;

public class VendedorContext : IVendedorContext
{
    private readonly IContextGeneral<Vendedor> _context;

    public VendedorContext(IContextGeneral<Vendedor> context)
    {
        _context = context;
    }

    public async Task<List<Vendedor>> GetAllAsync()
    {
        return await _context.GetAll();
    }

    public async Task<Vendedor> GetByIdAsync(int id)
    {
        Vendedor vendedor = await _context.GetById(id) ?? new Vendedor();
        return vendedor;
    }

    public async Task<Vendedor> InsertAsync(Vendedor vendedor)
    {
        vendedor.CreadoEn = DateTime.Now;
        vendedor.Activo = true;
        return await _context.Add(vendedor);
    }

    public async Task<(bool, string?)> UpdateAsync(Vendedor vendedor)
    {
        bool isUpdate = false;
        var result = await _context.GetById(vendedor.IdVendedor);

        if (result != null)
        {
            if (!string.IsNullOrEmpty(vendedor.Nombre) && vendedor.Nombre != result.Nombre)
            {
                result.Nombre = vendedor.Nombre;
                isUpdate = true;
            }

            if (!string.IsNullOrEmpty(vendedor.Telefono) && vendedor.Telefono != result.Telefono)
            {
                result.Telefono = vendedor.Telefono;
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

        return (false, "Vendedor no encontrado");
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

        return (false, "Vendedor no encontrado");
    }
}