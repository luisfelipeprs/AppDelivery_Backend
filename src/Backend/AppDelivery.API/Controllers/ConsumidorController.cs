using Microsoft.AspNetCore.Mvc;
using AppDelivery.Communication.Requests;
using AppDelivery.Communication.Responses;
using AppDelivery.Application.UseCases.User;
using AppDelivery.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using AppDelivery.Application.UseCases;
using AppDelivery.Application.UseCases.Consumidor;

namespace AppDelivery.API.Controllers;
[Route("[controller]")]
[ApiController]
public class ConsumidorController : ControllerBase
{
    // Create (Registro de usuário)
    [HttpPost]
    [ProducesResponseType(typeof(ResponseRegisteredConsumidorJson), StatusCodes.Status201Created)]
    public async Task<IActionResult> Register(
        [FromServices] IRegisterConsumidorUseCase useCase,
        [FromBody] RequestRegisterConsumidorJson request)
    {
        var result = await useCase.Execute(request);
        return Created(string.Empty, result);
    }

    // Read (Obter todos os usuários)
    [HttpGet]
    [ProducesResponseType(typeof(List<Consumidor>), StatusCodes.Status200OK)]
    public async Task<List<Consumidor>> GetConsumidores(
        [FromServices] IGetConsumidorUseCase useCase)
    {
        var result = await useCase.GetConsumidores();
        return result;
    }

    // Read (Obter usuário por ID)
    [HttpGet]
    [Route("{id}")]
    [ProducesResponseType(typeof(ResponseConsumerJson), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById(
        [FromServices] IGetConsumidorByIdUseCase useCases,
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
        [FromServices] IUpdateConsumidorUseCase useCase,
        [FromRoute] long id,
        [FromBody] RequestConsumidorJson request)
    {
        await useCase.Execute(id, request);

        return NoContent();
    }

    // Delete (Deletar consumidor por ID)
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteConsumidor(
        [FromServices] IDeleteConsumidorUseCase useCase,
        [FromRoute] int id)
    {
        await useCase.Execute(id);
        return NoContent();
    }
}
