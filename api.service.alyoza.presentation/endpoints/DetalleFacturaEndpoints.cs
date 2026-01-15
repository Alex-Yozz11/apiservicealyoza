using api.service.alyoza.application.commons.dtos;
using api.service.alyoza.application.ifeatures;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace api.service.alyoza.presentation.endpoint;

public static class DetalleFacturaEndpoints
{
    public static RouteGroupBuilder MapDetalleFactura(this RouteGroupBuilder builder)
    {
        builder.MapGet("/", GetAll);
        builder.MapGet("/{id:int}", GetById);
        builder.MapPost("/", Insert);
        builder.MapPatch("/{id:int}", Update);
        builder.MapDelete("/{id:int}/{softDelete:int}", Delete);
        return builder;
    }

    static async Task<Results<Ok<List<DetalleFacturaResponseDto>>, ProblemHttpResult>> GetAll(IDetalleFacturaHandler detalleFacturaHandler)
    {
        return TypedResults.Ok(await detalleFacturaHandler.GetAll());
    }

    static async Task<Results<Ok<DetalleFacturaResponseDto>, NotFound<string>, ProblemHttpResult>> GetById(
        [FromRoute] int id,
        IDetalleFacturaHandler detalleFacturaHandler)
    {
        var detalle = await detalleFacturaHandler.GetById(id);
        if (detalle.IdDetalle == 0)
        {
            return TypedResults.NotFound("No encontrado");
        }
        return TypedResults.Ok(detalle);
    }

    static async Task<Results<Created<DetalleFacturaResponseDto>, ProblemHttpResult>> Insert(
        [FromBody] DetalleFacturaRequestDto detalleRequest,
        IDetalleFacturaHandler detalleFacturaHandler)
    {
        var detalle = await detalleFacturaHandler.Insert(detalleRequest);
        return TypedResults.Created($"/v1/detallefactura/{detalle.IdDetalle}", detalle);
    }

    static async Task<Results<NoContent, NotFound<string>, ProblemHttpResult>> Update(
        [FromRoute] int id,
        [FromBody] DetalleFacturaRequestDto detalleRequest,
        IDetalleFacturaHandler detalleFacturaHandler)
    {
        var result = await detalleFacturaHandler.UpdateAsync(detalleRequest, id);

        if (!result.Item1 && result.Item2 != null)
        {
            return TypedResults.NotFound(result.Item2);
        }

        return TypedResults.NoContent();
    }

    static async Task<Results<NoContent, NotFound<string>, BadRequest<string>, ProblemHttpResult>> Delete(
        [FromRoute] int id,
        [FromRoute] int softDelete,
        IDetalleFacturaHandler detalleFacturaHandler)
    {
        if (softDelete < 0 || softDelete > 1)
        {
            return TypedResults.BadRequest("El valor softDelete debe ser 0 o 1");
        }

        var result = await detalleFacturaHandler.Delete(id, softDelete == 1);

        if (!result.Item1 && result.Item2 != null)
        {
            return TypedResults.NotFound(result.Item2);
        }

        return TypedResults.NoContent();
    }
}