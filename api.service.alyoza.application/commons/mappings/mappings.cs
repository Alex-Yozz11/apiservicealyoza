using api.service.ayoza.application.commons.dtos;
using api.service.alyoza.domain.clases;
using Riok.Mapperly.Abstractions;

namespace api.service.ayoza.application.commons.mappings;

[Mapper]
public partial class Mappings
{
    // Cliente
    public partial ClienteResponseDto ToResponseDto(Cliente cliente);
    public partial List<ClienteResponseDto> ToResponseDto(List<Cliente> clientes);
    public partial Cliente ToEntity(ClienteRequestDto clienteRequestDto);

    // Vendedor
    public partial VendedorResponseDto ToResponseDto(Vendedor vendedor);
    public partial List<VendedorResponseDto> ToResponseDto(List<Vendedor> vendedores);
    public partial Vendedor ToEntity(VendedorRequestDto vendedorRequestDto);

    // Vehiculo
    public partial VehiculoResponseDto ToResponseDto(Vehiculo vehiculo);
    public partial List<VehiculoResponseDto> ToResponseDto(List<Vehiculo> vehiculos);
    public partial Vehiculo ToEntity(VehiculoRequestDto vehiculoRequestDto);

    // TipoVehiculo
    public partial TipoVehiculoResponseDto ToResponseDto(TipoVehiculo tipoVehiculo);
    public partial List<TipoVehiculoResponseDto> ToResponseDto(List<TipoVehiculo> tiposVehiculo);
    public partial TipoVehiculo ToEntity(TipoVehiculoRequestDto tipoVehiculoRequestDto);

    // Factura
    public partial FacturaResponseDto ToResponseDto(Factura factura);
    public partial List<FacturaResponseDto> ToResponseDto(List<Factura> facturas);
    public partial Factura ToEntity(FacturaRequestDto facturaRequestDto);

    // DetalleFactura
    public partial DetalleFacturaResponseDto ToResponseDto(DetalleFactura detalleFactura);
    public partial List<DetalleFacturaResponseDto> ToResponseDto(List<DetalleFactura> detallesFactura);
    public partial DetalleFactura ToEntity(DetalleFacturaRequestDto detalleFacturaRequestDto);
}