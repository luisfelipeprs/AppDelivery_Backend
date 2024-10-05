using AppDelivery.Communication.Requests;
using AppDelivery.Domain.Entities;
using System.Net.WebSockets;

namespace AppDelivery.Application.UseCases.WebSocketTrackingDelivery;
public interface IWebSocketTrackingDeliveryUseCase
{
    Task HandleWebSocketConnection(WebSocket webSocket);
    Task TrackDeliveryCoordinates(GeolocationData data);
}
