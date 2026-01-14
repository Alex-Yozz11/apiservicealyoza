using api.service.alyoza.application.commons.dtos;
using api.service.alyoza.application.commons.mappings;
using api.service.alyoza.application.ifeatures;
using api.service.alyoza.infrastructure.context.detallefactura;

namespace api.service.alyoza.application.features;

public class DetalleFacturaHandler : IDetalleFacturaHandler
{
    private readonly Mappings _mapper;
    private readonly IDetalleFacturaContext _context;

    public DetalleFacturaHandler(IDetalleFacturaContext context, Mappings mapper)
    {
        _mapper = mapper;
        _context = context;
    }

    public async Task<List<DetalleFacturaResponseDto>> GetAll()
        => _mapper.ToResponseDto(await _context.GetAllAsync());

    public async Task<DetalleFacturaResponseDto> GetById(int id)
        => _mapper.ToResponseDto(await _context.GetByIdAsync(id));

    public async Task<DetalleFacturaResponseDto> Insert(DetalleFacturaRequestDto request)
        => _mapper.ToResponseDto(await _context.InsertAsync(_mapper.ToRequestDto(request)));

    public async Task<(bool, string?)> UpdateAsync(DetalleFacturaRequestDto request, int id)
    {
        var entity = _mapper.ToRequestDto(request);
        entity.IdDetalle = id;
        return await _context.UpdateAsync(entity);
    }

    public async Task<(bool, string?)> Delete(int id, bool softDelete)
        => await _context.Delete(id, softDelete);
}