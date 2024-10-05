using AppDelivery.Application.UseCases.ResetPassword;
using AppDelivery.Communication.Requests;
using AppDelivery.Communication.Responses;
using Microsoft.AspNetCore.Mvc;

namespace AppDelivery.API.Controllers;
[Route("[controller]")]
[ApiController]
public class ResetPasswordController : ControllerBase
{
    [HttpPost]
    [Route("reset-password")]
    [ProducesResponseType(typeof(ResponseResetPasswordJson), StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> ResetPassword(
        [FromServices] IResetPasswordUseCase useCase,
        [FromBody] RequestResetPasswordJson request)
    {
        await useCase.ResetPassword(request);
        return NoContent();
    }
    
    [HttpPost]
    [Route("confirm-reset")]
    [ProducesResponseType(typeof(ResponseResetPasswordJson), StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> ConfirmReset(
        [FromServices] IResetPasswordUseCase useCase,
        [FromBody] RequestConfirmResetJson request)
    {
        await useCase.ConfirmReset(request);
        return NoContent();
    }

}