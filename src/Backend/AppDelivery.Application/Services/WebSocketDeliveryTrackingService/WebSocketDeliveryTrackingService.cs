using System.Net;
using System.Net.WebSockets;
using System.Text;
namespace AppDelivery.Application.Services.WebSocketDeliveryTrackingService;
public class WebSocketDeliveryTrackingService
{
    private readonly List<WebSocket> _clients = new List<WebSocket>();

    public async Task HandleWebSocketConnection(WebSocket webSocket)
    {
        Console.WriteLine("Adicionando cliente à lista.");
        _clients.Add(webSocket);
        Console.WriteLine($"Clientes conectados: {_clients.Count}");

        var buffer = new byte[1024 * 4];

        while (webSocket.State == WebSocketState.Open)
        {
            var result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);

            if (result.MessageType == WebSocketMessageType.Text)
            {
                var message = Encoding.UTF8.GetString(buffer, 0, result.Count);
                Console.WriteLine($"Mensagem recebida: {message}");

                // Enviar a mensagem para todos os clientes conectados
                await SendMessageToClients(message);
            }
            else if (result.MessageType == WebSocketMessageType.Close)
            {
                await webSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, "Conexão fechada", CancellationToken.None);
                _clients.Remove(webSocket);
                Console.WriteLine("Cliente desconectado.");
            }
        }

        // Remover o cliente da lista quando a conexão é fechada
        _clients.Remove(webSocket);
    }

    public async Task SendMessageToClients(string message)
    {
        foreach (var client in _clients)
        {
            if (client.State == WebSocketState.Open)
            {
                Console.WriteLine($"Enviando mensagens: {message}");
                var buffer = Encoding.UTF8.GetBytes(message);
                var arraySegment = new ArraySegment<byte>(buffer);
                await client.SendAsync(arraySegment, WebSocketMessageType.Text, true, CancellationToken.None);
            }
        }
    }
}
