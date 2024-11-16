using AppDelivery.Application.UseCases.Company;
using AppDelivery.Application.UseCases.Consumer;
using AppDelivery.Application.UseCases.ResetPassword;
using AppDelivery.Communication.Requests;
using AppDelivery.Communication.Responses;
using AppDelivery.Domain.Entities;
using Azure;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations; // Import necessário

namespace AppDelivery.API.Controllers;

[Route("[controller]")]
[ApiController]
public class CompanyController : ControllerBase
{
    [HttpPost]
    [SwaggerOperation(Summary = "Registers a new company", Description = "Registers a new company with the provided details.")]
    [ProducesResponseType(typeof(ResponseRegisteredCompanyJson), StatusCodes.Status201Created)]
    public async Task<IActionResult> Register(
        [FromServices] IRegisterCompanyUseCase useCase,
        [FromBody] RequestRegisterCompanyJson request)
    {
        var result = await useCase.Execute(request);
        return Created(string.Empty, result);
    }

    [HttpPost]
    [Route("login")]
    [SwaggerOperation(Summary = "Logs in a company", Description = "Logs in a company with the provided credentials.")]
    [ProducesResponseType(typeof(ResponseLoginCompanyJson), StatusCodes.Status200OK)]
    public async Task<IActionResult> Login(
        [FromServices] ILoginCompanyUseCase useCase,
        [FromBody] RequestLoginCompanyJson request)
    {
        var (json, message) = await useCase.Login(request);
        if (json == null)
        {
            return BadRequest(message);
        }
        return Ok(json);
    }

    [HttpGet]
    [SwaggerOperation(Summary = "Gets all companies", Description = "Retrieves a list of all registered companies.")]
    [ProducesResponseType(typeof(ResponseCompaniesJson), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> GetCompany(
        [FromServices] IGetCompanyUseCase useCase)
    {
        var result = await useCase.GetCompanies();
        if (result.Companies.Count != 0)
        {
            return Ok(result);
        }
        return NoContent();
    }

    [HttpGet]
    [Route("{id}")]
    [SwaggerOperation(Summary = "Gets a company by ID", Description = "Retrieves the details of a company by its unique identifier.")]
    [ProducesResponseType(typeof(ResponseCompanyJson), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById(
        [FromServices] IGetCompanyByIdUseCase useCases,
        [FromRoute] Guid id)
    {
        var response = await useCases.Execute(id);
        return Ok(response);
    }

    [HttpPut]
    [Route("{id}")]
    [SwaggerOperation(Summary = "Updates a company", Description = "Updates the details of a company using its ID and the provided data.")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(
        [FromServices] IUpdateCompanyUseCase useCase,
        [FromRoute] Guid id,
        [FromBody] RequestCompanyJson request)
    {
        await useCase.Execute(id, request);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [SwaggerOperation(Summary = "Deletes a company", Description = "Deletes a company by its ID.")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(
        [FromServices] IDeleteCompanyUseCase useCase,
        [FromRoute] Guid id)
    {
        await useCase.Execute(id);
        return NoContent();
    }
}
