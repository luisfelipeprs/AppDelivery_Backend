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
    [Route("ws/{orderId}")]
    public async Task<IActionResult> WebSocketEndpoint(string orderId)
    {
        if (HttpContext.WebSockets.IsWebSocketRequest)
        {
            var webSocket = await HttpContext.WebSockets.AcceptWebSocketAsync();
            await _webSocketService.HandleWebSocketConnection(webSocket, orderId); // passa o orderId
            return new EmptyResult();
        }
        else
        {
            return BadRequest("A requisição não é um WebSocket.");
        }
    }
}
