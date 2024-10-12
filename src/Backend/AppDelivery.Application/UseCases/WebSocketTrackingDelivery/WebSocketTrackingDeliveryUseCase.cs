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

    public async Task HandleWebSocketConnection(WebSocket webSocket, string orderId)
    {
        await _webSocketService.HandleWebSocketConnection(webSocket, orderId); // Passa o orderId para o serviço
    }

    public async Task TrackDeliveryCoordinates(string idOrder, GeolocationData data)
    {
        var message = $"{data.IdOrder}: Latitude {data.Latitude}, Longitude {data.Longitude}";
        Console.WriteLine("Message > ", message);
        await _webSocketService.SendMessageToClients(idOrder, message); // Envia a mensagem para o idOrder correto
    }
}
