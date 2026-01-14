using api.service.alyoza.domain.clases;

namespace api.service.alyoza.infrastructure.context.detallefactura;

public class DetalleFacturaContext : IDetalleFacturaContext
{
    private readonly IContextGeneral<DetalleFactura> _context;

    public DetalleFacturaContext(IContextGeneral<DetalleFactura> context)
    {
        _context = context;
    }

    public async Task<List<DetalleFactura>> GetAllAsync()
    {
        return await _context.GetAll();
    }

    public async Task<DetalleFactura> GetByIdAsync(int id)
    {
        DetalleFactura detalle = await _context.GetById(id) ?? new DetalleFactura();
        return detalle;
    }

    public async Task<DetalleFactura> InsertAsync(DetalleFactura detalleFactura)
    {
        detalleFactura.CreadoEn = DateTime.Now;
        detalleFactura.Activo = true;
        return await _context.Add(detalleFactura);
    }

    public async Task<(bool, string?)> UpdateAsync(DetalleFactura detalleFactura)
    {
        bool isUpdate = false;
        var result = await _context.GetById(detalleFactura.IdDetalle);

        if (result != null)
        {
            if (detalleFactura.IdFactura != result.IdFactura)
            {
                result.IdFactura = detalleFactura.IdFactura;
                isUpdate = true;
            }

            if (detalleFactura.IdVehiculo != result.IdVehiculo)
            {
                result.IdVehiculo = detalleFactura.IdVehiculo;
                isUpdate = true;
            }

            if (detalleFactura.Cantidad != result.Cantidad)
            {
                result.Cantidad = detalleFactura.Cantidad;
                isUpdate = true;
            }

            if (detalleFactura.PrecioUnitario != result.PrecioUnitario)
            {
                result.PrecioUnitario = detalleFactura.PrecioUnitario;
                isUpdate = true;
            }

            if (detalleFactura.SubtotalLinea != result.SubtotalLinea)
            {
                result.SubtotalLinea = detalleFactura.SubtotalLinea;
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

        return (false, "DetalleFactura no encontrado");
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

        return (false, "DetalleFactura no encontrado");
    }
}