using api.service.alyoza.domain.clases;

namespace api.service.alyoza.infrastructure.context.tipovehiculo;

public class TipoVehiculoContext : ITipoVehiculoContext
{
    private readonly IContextGeneral<TipoVehiculo> _context;

    public TipoVehiculoContext(IContextGeneral<TipoVehiculo> context)
    {
        _context = context;
    }

    public async Task<List<TipoVehiculo>> GetAllAsync()
    {
        return await _context.GetAll();
    }

    public async Task<TipoVehiculo> GetByIdAsync(int id)
    {
        TipoVehiculo tipoVehiculo = await _context.GetById(id) ?? new TipoVehiculo();
        return tipoVehiculo;
    }

    public async Task<TipoVehiculo> InsertAsync(TipoVehiculo tipoVehiculo)
    {
        tipoVehiculo.CreadoEn = DateTime.Now;
        tipoVehiculo.Activo = true;
        return await _context.Add(tipoVehiculo);
    }

    public async Task<(bool, string?)> UpdateAsync(TipoVehiculo tipoVehiculo)
    {
        bool isUpdate = false;
        var result = await _context.GetById(tipoVehiculo.IdTipoVehiculo);

        if (result != null)
        {
            if (!string.IsNullOrEmpty(tipoVehiculo.Nombre) && tipoVehiculo.Nombre != result.Nombre)
            {
                result.Nombre = tipoVehiculo.Nombre;
                isUpdate = true;
            }

            if (!string.IsNullOrEmpty(tipoVehiculo.Descripcion) && tipoVehiculo.Descripcion != result.Descripcion)
            {
                result.Descripcion = tipoVehiculo.Descripcion;
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

        return (false, "TipoVehículo no encontrado");
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

        return (false, "TipoVehículo no encontrado");
    }
}