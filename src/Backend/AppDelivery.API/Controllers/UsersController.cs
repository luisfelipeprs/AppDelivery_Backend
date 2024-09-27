using Microsoft.AspNetCore.Mvc;
using AppDelivery.Communication.Requests;
using AppDelivery.Communication.Responses;
using AppDelivery.Application.UseCases.User;
using AppDelivery.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using AppDelivery.Application.UseCases;

namespace AppDelivery.API.Controllers;
[Route("[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    // Create (Registro de usuário)
    [HttpPost]
    [ProducesResponseType(typeof(ResponseRegisteredUserJson), StatusCodes.Status201Created)]
    public async Task<IActionResult> Register(
        [FromServices] IRegisterUserUseCase useCase,
        [FromBody] RequestRegisterUserJson request)
    {
        var result = await useCase.Execute(request);
        return Created(string.Empty, result);
    }

    // Read (Obter todos os usuários)
    [HttpGet]
    [ProducesResponseType(typeof(List<User>), StatusCodes.Status200OK)]
    public async Task<List<User>> GetUsers(
        [FromServices] IGetUsersUseCase useCase)
    {
        var result = await useCase.GetUsers();
        return result;
    }

    // Read (Obter usuário por ID)
    [HttpGet]
    [Route("{id}")]
    [ProducesResponseType(typeof(ResponseUserJson), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById(
        [FromServices] IGetUserByIdUseCase useCases,
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
        [FromServices] IUpdateUserUseCase useCase,
        [FromRoute] long id,
        [FromBody] RequestUserJson request)
    {
        await useCase.Execute(id, request);

        return NoContent();
    }

    // Delete (Deletar usuário por ID)
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteUser(
        [FromServices] IDeleteUserUseCase useCase,
        [FromRoute] int id)
    {
        await useCase.Execute(id);
        return NoContent();
    }
}
