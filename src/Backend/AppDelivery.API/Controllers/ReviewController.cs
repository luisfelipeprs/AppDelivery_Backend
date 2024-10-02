using AppDelivery.Application.UseCases.Review;
using AppDelivery.Communication.Requests;
using AppDelivery.Communication.Responses;
using AppDelivery.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace AppDelivery.API.Controllers;
[Route("[controller]")]
[ApiController]
public class ReviewController : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(ResponseRegisteredReviewJson), StatusCodes.Status201Created)]
    public async Task<IActionResult> Register(
        [FromServices] IRegisterReviewUseCase useCase,
        [FromBody] RequestReviewJson request)
    {
        var result = await useCase.Execute(request);
        return Created(string.Empty, result);
    }

    [HttpGet]
    [ProducesResponseType(typeof(List<Review>), StatusCodes.Status200OK)]
    public async Task<List<Review>> GetReviews(
        [FromServices] IGetReviewUseCase useCase)
    {
        var result = await useCase.GetReviews();
        return result;
    }

    [HttpGet]
    [Route("{id}")]
    [ProducesResponseType(typeof(ResponseReviewJson), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById(
        [FromServices] IGetReviewByIdUseCase useCases,
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
        [FromServices] IUpdateReviewUseCase useCase,
        [FromRoute] long id,
        [FromBody] RequestReviewJson request)
    {
        await useCase.Execute(id, request);

        return NoContent();
    }

    // Delete (Deletar review por ID)
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteReview(
        [FromServices] IDeleteReviewUseCase useCase,
        [FromRoute] int id)
    {
        await useCase.Execute(id);
        return NoContent();
    }
}
