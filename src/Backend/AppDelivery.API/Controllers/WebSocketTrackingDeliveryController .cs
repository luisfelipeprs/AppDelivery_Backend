using AppDelivery.Application.Services.WebSocketDeliveryTrackingService;
using AppDelivery.Application.UseCases.WebSocketTrackingDelivery;
using Microsoft.AspNetCore.Mvc;
using System.Net.WebSockets;

namespace AppDelivery.API.Controllers;
[Route("[controller]")]
[ApiController]
public class WebSocketTrackingDeliveryController : ControllerBase
{
    private readonly IWebSocketTrackingDeliveryUseCase _useCase;
    private readonly WebSocketDeliveryTrackingService _webSocketService;

    public WebSocketTrackingDeliveryController(IWebSocketTrackingDeliveryUseCase useCase, WebSocketDeliveryTrackingService webSocketService)
    {
        _useCase = useCase;
        _webSocketService = webSocketService;
    }

    [HttpGet]
    [Route("ws")]
    public async Task<IActionResult> WebSocketEndpoint()
    {
        if (HttpContext.WebSockets.IsWebSocketRequest)
        {
            var webSocket = await HttpContext.WebSockets.AcceptWebSocketAsync();
            await _webSocketService.HandleWebSocketConnection(webSocket);
            return new EmptyResult(); // Retorna uma resposta vazia após o processamento do WebSocket
        }
        else
        {
            return BadRequest("A requisição não é um WebSocket."); // Retorna erro se não for uma requisição WebSocket
        }
    }
}
