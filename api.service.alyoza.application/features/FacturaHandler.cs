using api.service.alyoza.application.commons.dtos;
using api.service.alyoza.application.commons.mappings;
using api.service.alyoza.application.ifeatures;
using api.service.alyoza.infrastructure.context.factura;

namespace api.service.alyoza.application.features;

public class FacturaHandler : IFacturaHandler
{
    private readonly Mappings _mapper;
    private readonly IFacturaContext _context;

    public FacturaHandler(IFacturaContext context, Mappings mapper)
    {
        _mapper = mapper;
        _context = context;
    }

    public async Task<List<FacturaResponseDto>> GetAll()
        => _mapper.ToResponseDto(await _context.GetAllAsync());

    public async Task<FacturaResponseDto> GetById(int id)
        => _mapper.ToResponseDto(await _context.GetByIdAsync(id));

    public async Task<FacturaResponseDto> Insert(FacturaRequestDto request)
        => _mapper.ToResponseDto(await _context.InsertAsync(_mapper.ToRequestDto(request)));

    public async Task<(bool, string?)> UpdateAsync(FacturaRequestDto request, int id)
    {
        var entity = _mapper.ToRequestDto(request);
        entity.IdFactura = id;
        return await _context.UpdateAsync(entity);
    }

    public async Task<(bool, string?)> Delete(int id, bool softDelete)
        => await _context.Delete(id, softDelete);
}