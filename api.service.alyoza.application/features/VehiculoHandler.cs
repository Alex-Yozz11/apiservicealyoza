using api.service.alyoza.application.commons.dtos;
using api.service.alyoza.application.commons.mappings;
using api.service.alyoza.application.ifeatures;
using api.service.alyoza.infrastructure.context.vehiculo;

namespace api.service.alyoza.application.features;

public class VehiculoHandler : IVehiculoHandler
{
    private readonly Mappings _mapper;
    private readonly IVehiculoContext _context;

    public VehiculoHandler(IVehiculoContext context, Mappings mapper)
    {
        _mapper = mapper;
        _context = context;
    }

    public async Task<List<VehiculoResponseDto>> GetAll()
        => _mapper.ToResponseDto(await _context.GetAllAsync());

    public async Task<VehiculoResponseDto> GetById(int id)
        => _mapper.ToResponseDto(await _context.GetByIdAsync(id));

    public async Task<VehiculoResponseDto> Insert(VehiculoRequestDto request)
        => _mapper.ToResponseDto(await _context.InsertAsync(_mapper.ToRequestDto(request)));

    public async Task<(bool, string?)> UpdateAsync(VehiculoRequestDto request, int id)
    {
        var entity = _mapper.ToRequestDto(request);
        entity.IdVehiculo = id;
        return await _context.UpdateAsync(entity);
    }

    public async Task<(bool, string?)> Delete(int id, bool softDelete)
        => await _context.Delete(id, softDelete);
}