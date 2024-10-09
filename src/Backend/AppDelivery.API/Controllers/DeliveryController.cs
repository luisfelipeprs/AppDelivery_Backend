using AppDelivery.Application.UseCases.Delivery;
using AppDelivery.Communication.Requests;
using AppDelivery.Communication.Responses;
using AppDelivery.Domain.Entities;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Mvc;

namespace AppDelivery.API.Controllers;
[Route("[controller]")]
[ApiController]
public class DeliveryController : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(ResponseRegisteredDeliveryJson), StatusCodes.Status201Created)]
    public async Task<IActionResult> Register(
        [FromServices] IRegisterDeliveryUseCase useCase,
        [FromBody] RequestRegisterDeliveryJson request)
    {
        var result = await useCase.Execute(request);
        return Created(string.Empty, result);
    }

    [HttpGet]
    [ProducesResponseType(typeof(List<Delivery>), StatusCodes.Status200OK)]
    public async Task<List<Delivery>> GetDeliveries(
        [FromServices] IGetDeliveryUseCase useCase)
    {
        var result = await useCase.GetDeliveries();
        return result;
    }

    [HttpGet]
    [Route("delivery-records")]
    [ProducesResponseType(typeof(List<Delivery>), StatusCodes.Status200OK)]
    public async Task<List<Delivery>> GetDeliveriesRecords(
        [FromServices] IGetDeliveryUseCase useCase)
    {
        var result = await useCase.GetDeliveriesRecords();
        return result;
    }

    [HttpGet]
    [Route("{id}")]
    [ProducesResponseType(typeof(ResponseDeliveryJson), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById(
        [FromServices] IGetDeliveryByIdUseCase useCases,
        [FromRoute] Guid id)
    {
        var response = await useCases.Execute(id);

        return Ok(response);
    }

    [HttpPut]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(
        [FromServices] IUpdateDeliveryUseCase useCase,
        [FromRoute] Guid id,
        [FromBody] RequestDeliveryJson request)
    {
        await useCase.Execute(id, request);

        return NoContent();
    }


    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteDelivery(
        [FromServices] IDeleteDeliveryUseCase useCase,
        [FromRoute] Guid id)
    {
        await useCase.Execute(id);
        return NoContent();
    }
}
