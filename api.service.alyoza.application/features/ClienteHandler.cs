using api.service.ayoza.application.commons.dtos;
using api.service.ayoza.application.commons.mappings;
using api.service.ayoza.application.ifeatures;
using api.service.alyoza.infrastructure.context.cliente;

namespace api.service.ayoza.application.features;

public class ClienteHandler : IClienteHandler
{
    private readonly Mappings _mapper;
    private readonly IClienteContext _context;

    public ClienteHandler(IClienteContext context)
    {
        _mapper = new Mappings();
        _context = context;
    }

    public async Task<List<ClienteResponseDto>> GetAll()
        => _mapper.ToResponseDto(await _context.GetAllAsync());

    public async Task<ClienteResponseDto> GetById(int id)
        => _mapper.ToResponseDto(await _context.GetByIdAsync(id));

    public async Task<ClienteResponseDto> Insert(ClienteRequestDto request)
        => _mapper.ToResponseDto(await _context.InsertAsync(_mapper.ToRequestDto(request)));

    public async Task<(bool, string?)> UpdateAsync(ClienteRequestDto request, int id)
    {
        var entity = _mapper.ToRequestDto(request);
        entity.IdCliente = id;
        return await _context.UpdateAsync(entity);
    }

    public async Task<(bool, string?)> Delete(int id, bool softDelete)
        => await _context.Delete(id, softDelete);
}