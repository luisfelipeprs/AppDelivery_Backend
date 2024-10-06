using AppDelivery.Application.UseCases.Company;
using AppDelivery.Application.UseCases.Consumer;
using AppDelivery.Application.UseCases.ResetPassword;
using AppDelivery.Communication.Requests;
using AppDelivery.Communication.Responses;
using AppDelivery.Domain.Entities;
using Azure;
using Microsoft.AspNetCore.Mvc;

namespace AppDelivery.API.Controllers;
[Route("[controller]")]
[ApiController]
public class CompanyController : ControllerBase
{
    [HttpPost]
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
    [ProducesResponseType(typeof(ResponseLoginCompanyJson), StatusCodes.Status200OK)]
    public async Task<IActionResult> Login(
        [FromServices] ILoginCompanyUseCase useCase,
        [FromBody] RequestLoginCompanyJson request)
    {
        var (json, message) = await useCase.Login(request);
        if (json == null) {
            return BadRequest(message);
        }
        return Ok(json);
    }

    [HttpGet]
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

    // Read (Obter usuário por ID)
    [HttpGet]
    [Route("{id}")]
    [ProducesResponseType(typeof(ResponseCompanyJson), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById(
        [FromServices] IGetCompanyByIdUseCase useCases,
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
        [FromServices] IUpdateCompanyUseCase useCase,
        [FromRoute] long id,
        [FromBody] RequestCompanyJson request)
    {
        await useCase.Execute(id, request);

        return NoContent();
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(
        [FromServices] IDeleteCompanyUseCase useCase,
        [FromRoute] int id)
    {
       await useCase.Execute(id);
        return NoContent();
    }
}
