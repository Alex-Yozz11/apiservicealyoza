using api.service.alyoza.application.commons.dtos;
using api.service.alyoza.domain.clases;
using Riok.Mapperly.Abstractions;

namespace api.service.alyoza.application.commons.mappings;

[Mapper]
public partial class Mappings
{
    public partial ClienteResponseDto ToResponseDto(Cliente cliente);
    public partial List<ClienteResponseDto> ToResponseDto(List<Cliente> clientes);

    public partial VendedorResponseDto ToResponseDto(Vendedor vendedor);
    public partial List<VendedorResponseDto> ToResponseDto(List<Vendedor> vendedores);

    public partial VehiculoResponseDto ToResponseDto(Vehiculo vehiculo);
    public partial List<VehiculoResponseDto> ToResponseDto(List<Vehiculo> vehiculos);

    public partial TipoVehiculoResponseDto ToResponseDto(TipoVehiculo tipoVehiculo);
    public partial List<TipoVehiculoResponseDto> ToResponseDto(List<TipoVehiculo> tiposVehiculo);

    public partial FacturaResponseDto ToResponseDto(Factura factura);
    public partial List<FacturaResponseDto> ToResponseDto(List<Factura> facturas);

    public partial DetalleFacturaResponseDto ToResponseDto(DetalleFactura detalleFactura);
    public partial List<DetalleFacturaResponseDto> ToResponseDto(List<DetalleFactura> detallesFactura);

    public partial Cliente ToRequestDto(ClienteRequestDto clienteRequestDto);
    public partial Vendedor ToRequestDto(VendedorRequestDto vendedorRequestDto);
    public partial Vehiculo ToRequestDto(VehiculoRequestDto vehiculoRequestDto);
    public partial TipoVehiculo ToRequestDto(TipoVehiculoRequestDto tipoVehiculoRequestDto);
    public partial Factura ToRequestDto(FacturaRequestDto facturaRequestDto);
    public partial DetalleFactura ToRequestDto(DetalleFacturaRequestDto detalleFacturaRequestDto);
}