using api.service.alyoza.application.commons.dtos;
using api.service.alyoza.application.commons.mappings;
using api.service.alyoza.application.ifeatures;
using api.service.alyoza.infrastructure.context.vendedor;

namespace api.service.alyoza.application.features;

public class VendedorHandler : IVendedorHandler
{
    private readonly Mappings _mapper;
    private readonly IVendedorContext _context;

    public VendedorHandler(IVendedorContext context, Mappings mapper)
    {
        _mapper = mapper;
        _context = context;
    }

    public async Task<List<VendedorResponseDto>> GetAll()
        => _mapper.ToResponseDto(await _context.GetAllAsync());

    public async Task<VendedorResponseDto> GetById(int id)
        => _mapper.ToResponseDto(await _context.GetByIdAsync(id));

    public async Task<VendedorResponseDto> Insert(VendedorRequestDto request)
        => _mapper.ToResponseDto(await _context.InsertAsync(_mapper.ToRequestDto(request)));

    public async Task<(bool, string?)> UpdateAsync(VendedorRequestDto request, int id)
    {
        var entity = _mapper.ToRequestDto(request);
        entity.IdVendedor = id;
        return await _context.UpdateAsync(entity);
    }

    public async Task<(bool, string?)> Delete(int id, bool softDelete)
        => await _context.Delete(id, softDelete);
}