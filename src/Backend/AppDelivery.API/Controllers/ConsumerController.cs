using AppDelivery.Application.UseCases.Consumer;
using AppDelivery.Communication.Requests;
using AppDelivery.Communication.Responses;
using AppDelivery.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace AppDelivery.API.Controllers;
[Route("[controller]")]
[ApiController]
public class ConsumerController : ControllerBase
{
    // Create (Registro de usuário)
    [HttpPost]
    [ProducesResponseType(typeof(ResponseRegisteredConsumerJson), StatusCodes.Status201Created)]
    public async Task<IActionResult> Register(
        [FromServices] IRegisterConsumerUseCase useCase,
        [FromBody] RequestRegisterConsumerJson request)
    {
        var result = await useCase.Execute(request);
        return Created(string.Empty, result);
    }

    // Read (Obter todos os usuários)
    [HttpGet]
    [ProducesResponseType(typeof(List<Consumer>), StatusCodes.Status200OK)]
    public async Task<List<Consumer>> GetConsumers(
        [FromServices] IGetConsumerUseCase useCase)
    {
        var result = await useCase.GetConsumers();
        return result;
    }

    // Read (Obter usuário por ID)
    [HttpGet]
    [Route("{id}")]
    [ProducesResponseType(typeof(ResponseConsumerJson), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById(
        [FromServices] IGetConsumerByIdUseCase useCases,
        [FromRoute] long id)
    {
        var response = await useCases.Execute(id);

        return Ok(response);
    }

    // Update (Atualizar usuário por ID)
    [HttpPut]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(
        [FromServices] IUpdateConsumerUseCase useCase,
        [FromRoute] long id,
        [FromBody] RequestConsumerJson request)
    {
        await useCase.Execute(id, request);

        return NoContent();
    }

    // Delete (Deletar consumer por ID)
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteConsumer(
        [FromServices] IDeleteConsumerUseCase useCase,
        [FromRoute] int id)
    {
        await useCase.Execute(id);
        return NoContent();
    }
}
