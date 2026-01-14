using api.service.ayoza.application.commons.dtos;
using api.service.ayoza.application.commons.mappings;
using api.service.ayoza.application.ifeatures;
using api.service.alyoza.infrastructure.context.tipovehiculo;

namespace api.service.ayoza.application.features;

public class TipoVehiculoHandler : ITipoVehiculoHandler
{
    private readonly Mappings _mapper;
    private readonly ITipoVehiculoContext _context;

    public TipoVehiculoHandler(ITipoVehiculoContext context)
    {
        _mapper = new Mappings();
        _context = context;
    }

    public async Task<List<TipoVehiculoResponseDto>> GetAll()
        => _mapper.ToResponseDto(await _context.GetAllAsync());

    public async Task<TipoVehiculoResponseDto> GetById(int id)
        => _mapper.ToResponseDto(await _context.GetByIdAsync(id));

    public async Task<TipoVehiculoResponseDto> Insert(TipoVehiculoRequestDto request)
        => _mapper.ToResponseDto(await _context.InsertAsync(_mapper.ToRequestDto(request)));

    public async Task<(bool, string?)> UpdateAsync(TipoVehiculoRequestDto request, int id)
    {
        var entity = _mapper.ToRequestDto(request);
        entity.IdTipoVehiculo = id;
        return await _context.UpdateAsync(entity);
    }

    public async Task<(bool, string?)> Delete(int id, bool softDelete)
        => await _context.Delete(id, softDelete);
}