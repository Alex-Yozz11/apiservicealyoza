using api.service.alyoza.domain.clases;

namespace api.service.alyoza.infrastructure.context.vehiculo;

public class VehiculoContext : IVehiculoContext
{
    private readonly IContextGeneral<Vehiculo> _context;

    public VehiculoContext(IContextGeneral<Vehiculo> context)
    {
        _context = context;
    }

    public async Task<List<Vehiculo>> GetAllAsync()
    {
        return await _context.GetAll();
    }

    public async Task<Vehiculo> GetByIdAsync(int id)
    {
        Vehiculo vehiculo = await _context.GetById(id) ?? new Vehiculo();
        return vehiculo;
    }

    public async Task<Vehiculo> InsertAsync(Vehiculo vehiculo)
    {
        vehiculo.CreadoEn = DateTime.Now;
        vehiculo.Activo = true;
        return await _context.Add(vehiculo);
    }

    public async Task<(bool, string?)> UpdateAsync(Vehiculo vehiculo)
    {
        bool isUpdate = false;
        var result = await _context.GetById(vehiculo.IdVehiculo);

        if (result != null)
        {
            if (!string.IsNullOrEmpty(vehiculo.Marca) && vehiculo.Marca != result.Marca)
            {
                result.Marca = vehiculo.Marca;
                isUpdate = true;
            }

            if (!string.IsNullOrEmpty(vehiculo.Modelo) && vehiculo.Modelo != result.Modelo)
            {
                result.Modelo = vehiculo.Modelo;
                isUpdate = true;
            }

            if (vehiculo.Anio.HasValue && vehiculo.Anio != result.Anio)
            {
                result.Anio = vehiculo.Anio;
                isUpdate = true;
            }

            if (vehiculo.Precio != result.Precio)
            {
                result.Precio = vehiculo.Precio;
                isUpdate = true;
            }

            if (vehiculo.IdTipoVehiculo != result.IdTipoVehiculo)
            {
                result.IdTipoVehiculo = vehiculo.IdTipoVehiculo;
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

        return (false, "Vehículo no encontrado");
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

        return (false, "Vehículo no encontrado");
    }
}