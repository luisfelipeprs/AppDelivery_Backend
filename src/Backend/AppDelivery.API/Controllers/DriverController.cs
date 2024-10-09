using AppDelivery.Application.UseCases.Driver;
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
    [HttpPost]
    [ProducesResponseType(typeof(ResponseRegisteredDriverJson), StatusCodes.Status201Created)]
    public async Task<IActionResult> Register(
        [FromServices] IRegisterDriverUseCase useCase,
        [FromBody] RequestRegisterDriverJson request)
    {
        var result = await useCase.Execute(request);
        return Created(string.Empty, result);
    }

    [HttpPost]
    [Route("login")]
    [ProducesResponseType(typeof(ResponseLoginDriverJson), StatusCodes.Status200OK)]
    public async Task<IActionResult> Login(
    [FromServices] ILoginDriverUseCase useCase,
    [FromBody] RequestLoginDriverJson request)
    {
        var (json, message) = await useCase.Login(request);
        if (json == null)
        {
            return BadRequest(message);
        }
        return Ok(json);
    }

    [HttpGet]
    [ProducesResponseType(typeof(ResponseDriversJson), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseDriversJson), StatusCodes.Status204NoContent)]
    public async Task<IActionResult> GetDrivers(
        [FromServices] IGetDriverUseCase useCase)
    {
        var result = await useCase.GetDrivers();
        if (result.Drivers.Count != 0)
        {
            return Ok(result);
        }
        return NoContent();
    }

    [HttpGet]
    [Route("{id}")]
    [ProducesResponseType(typeof(ResponseDriverByIdJson), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById(
        [FromServices] IGetDriverByIdUseCase useCases,
        [FromRoute] Guid id)
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
        [FromRoute] Guid id,
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
        [FromRoute] Guid id)
    {
        await useCase.Execute(id);
        return NoContent();
    }
}
