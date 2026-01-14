using api.service.alyoza.domain.clases;

namespace api.service.alyoza.infrastructure.context.factura;

public class FacturaContext : IFacturaContext
{
    private readonly IContextGeneral<Factura> _context;

    public FacturaContext(IContextGeneral<Factura> context)
    {
        _context = context;
    }

    public async Task<List<Factura>> GetAllAsync()
    {
        return await _context.GetAll();
    }

    public async Task<Factura> GetByIdAsync(int id)
    {
        Factura factura = await _context.GetById(id) ?? new Factura();
        return factura;
    }

    public async Task<Factura> InsertAsync(Factura factura)
    {
        factura.CreadoEn = DateTime.Now;
        factura.Activo = true;
        return await _context.Add(factura);
    }

    public async Task<(bool, string?)> UpdateAsync(Factura factura)
    {
        bool isUpdate = false;
        var result = await _context.GetById(factura.IdFactura);

        if (result != null)
        {
            if (factura.Fecha != result.Fecha)
            {
                result.Fecha = factura.Fecha;
                isUpdate = true;
            }

            if (!string.IsNullOrEmpty(factura.Estado) && factura.Estado != result.Estado)
            {
                result.Estado = factura.Estado;
                isUpdate = true;
            }

            if (factura.Subtotal != result.Subtotal)
            {
                result.Subtotal = factura.Subtotal;
                isUpdate = true;
            }

            if (factura.Impuesto != result.Impuesto)
            {
                result.Impuesto = factura.Impuesto;
                isUpdate = true;
            }

            if (factura.Total != result.Total)
            {
                result.Total = factura.Total;
                isUpdate = true;
            }

            if (factura.IdCliente != result.IdCliente)
            {
                result.IdCliente = factura.IdCliente;
                isUpdate = true;
            }

            if (factura.IdVendedor != result.IdVendedor)
            {
                result.IdVendedor = factura.IdVendedor;
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

        return (false, "Factura no encontrada");
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

        return (false, "Factura no encontrada");
    }
}