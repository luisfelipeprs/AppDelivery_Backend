using AppDelivery.Application.UseCases.Driver;
using AppDelivery.Communication.Requests;
using AppDelivery.Communication.Responses;
using AppDelivery.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace AppDelivery.API.Controllers;
[Route("[controller]")]
[ApiController]
public class DriverController : ControllerBase
{
    // Create (Registro de usuário)
    [HttpPost]
    [ProducesResponseType(typeof(ResponseRegisteredDriverJson), StatusCodes.Status201Created)]
    public async Task<IActionResult> Register(
        [FromServices] IRegisterDriverUseCase useCase,
        [FromBody] RequestRegisterDriverJson request)
    {
        var result = await useCase.Execute(request);
        return Created(string.Empty, result);
    }

    [HttpGet]
    [ProducesResponseType(typeof(List<Driver>), StatusCodes.Status200OK)]
    public async Task<List<Driver>> GetDrivers(
        [FromServices] IGetDriverUseCase useCase)
    {
        var result = await useCase.GetDrivers();
        return result;
    }

    [HttpGet]
    [Route("{id}")]
    [ProducesResponseType(typeof(ResponseDriverJson), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById(
        [FromServices] IGetDriverByIdUseCase useCases,
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
        [FromServices] IUpdateDriverUseCase useCase,
        [FromRoute] long id,
        [FromBody] RequestDriverJson request)
    {
        await useCase.Execute(id, request);

        return NoContent();
    }

    // Delete (Deletar driver por ID)
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteDriver(
        [FromServices] IDeleteDriverUseCase useCase,
        [FromRoute] int id)
    {
        await useCase.Execute(id);
        return NoContent();
    }
}
