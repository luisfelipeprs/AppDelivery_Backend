using AppDelivery.Application.UseCases.Order;
using AppDelivery.Communication.Requests;
using AppDelivery.Communication.Responses;
using AppDelivery.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace AppDelivery.API.Controllers;
[Route("[controller]")]
[ApiController]
public class OrderController : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(ResponseRegisteredOrderJson), StatusCodes.Status201Created)]
    public async Task<IActionResult> Register(
        [FromServices] IRegisterOrderUseCase useCase,
        [FromBody] RequestRegisterOrderJson request)
    {
        var result = await useCase.Execute(request);
        return Created(string.Empty, result);
    }

    [HttpGet]
    [ProducesResponseType(typeof(List<Order>), StatusCodes.Status200OK)]
    public async Task<List<Order>> GetOrders(
        [FromServices] IGetOrderUseCase useCase)
    {
        var result = await useCase.GetOrders();
        return result;
    }

    [HttpGet]
    [Route("{id}")]
    [ProducesResponseType(typeof(ResponseOrderJson), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById(
        [FromServices] IGetOrderByIdUseCase useCases,
        [FromRoute] long id)
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
        [FromServices] IUpdateOrderUseCase useCase,
        [FromRoute] long id,
        [FromBody] RequestOrderJson request)
    {
        await useCase.Execute(id, request);

        return NoContent();
    }


    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteOrder(
        [FromServices] IDeleteOrderUseCase useCase,
        [FromRoute] int id)
    {
        await useCase.Execute(id);
        return NoContent();
    }
}
