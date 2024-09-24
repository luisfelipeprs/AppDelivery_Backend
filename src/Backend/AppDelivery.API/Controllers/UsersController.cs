using Microsoft.AspNetCore.Mvc;
using AppDelivery.Communication.Requests;
using AppDelivery.Communication.Responses;
using AppDelivery.Application.UseCases.User;

namespace AppDelivery.API.Controllers;
[Route("[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(ResponseRegisteredUserJson), StatusCodes.Status201Created)]
    public async Task<IActionResult> Register(
        [FromServices] IRegisterUserUseCase useCase,
        [FromBody] RequestRegisterUserJson request)
    {
        var result = await useCase.Execute(request);

        return Created(string.Empty, result);
        
    }
}
