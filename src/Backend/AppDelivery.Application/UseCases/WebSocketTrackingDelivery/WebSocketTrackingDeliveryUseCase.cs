using AppDelivery.Application.Services.WebSocketDeliveryTrackingService;
using AppDelivery.Application.UseCases.WebSocketTrackingDelivery;
using AppDelivery.Domain.Entities;
using System.Net.WebSockets;

public class WebSocketTrackingDeliveryUseCase : IWebSocketTrackingDeliveryUseCase
{
    private readonly WebSocketDeliveryTrackingService _webSocketService;

    public WebSocketTrackingDeliveryUseCase(WebSocketDeliveryTrackingService webSocketService)
    {
        _webSocketService = webSocketService;
    }

    public async Task HandleWebSocketConnection(WebSocket webSocket)
    {
        await _webSocketService.HandleWebSocketConnection(webSocket);
    }

    public async Task TrackDeliveryCoordinates(GeolocationData data)
    {
        var message = $"{data.IdOrder}: Latitude {data.Latitude}, Longitude {data.Longitude}";
        await _webSocketService.SendMessageToClients(message);
    }
}
