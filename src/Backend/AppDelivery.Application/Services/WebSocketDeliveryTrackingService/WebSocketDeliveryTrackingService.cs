using System.Collections.Concurrent;
using System.Net.WebSockets;
using System.Text;

namespace AppDelivery.Application.Services.WebSocketDeliveryTrackingService
{
    public class WebSocketDeliveryTrackingService
    {
        // isso aqui vai mapear o carai do idOrder para a lista de websockets conectados
        private readonly ConcurrentDictionary<string, List<WebSocket>> _clientsByOrderId = new ConcurrentDictionary<string, List<WebSocket>>();

        public async Task HandleWebSocketConnection(WebSocket webSocket, string idOrder)
        {
            _clientsByOrderId.AddOrUpdate(idOrder,
                _ => new List<WebSocket> { webSocket },
                (_, sockets) =>
                {
                    sockets.Add(webSocket);
                    return sockets;
                });

            var buffer = new byte[1024 * 4];

            while (webSocket.State == WebSocketState.Open)
            {
                var result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);

                if (result.MessageType == WebSocketMessageType.Text)
                {
                    var message = Encoding.UTF8.GetString(buffer, 0, result.Count);
                    Console.WriteLine($"Mensagem recebida: {message}");
                    await SendMessageToClients(idOrder, message);
                }
                else if (result.MessageType == WebSocketMessageType.Close)
                {
                    await webSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, "Conexão fechada", CancellationToken.None);
                    // removo cliente da lista ao fechar a conexão
                    RemoveClient(idOrder, webSocket);
                    Console.WriteLine("Cliente desconectado.");
                }
            }

            RemoveClient(idOrder, webSocket);
        }

        private void RemoveClient(string idOrder, WebSocket webSocket)
        {
            if (_clientsByOrderId.TryGetValue(idOrder, out var clients))
            {
                clients.Remove(webSocket);
                if (clients.Count == 0)
                {
                    _clientsByOrderId.TryRemove(idOrder, out _);
                }
            }
        }

        public async Task SendMessageToClients(string idOrder, string message)
        {
            if (_clientsByOrderId.TryGetValue(idOrder, out var clients))
            {
                foreach (var client in clients)
                {
                    if (client.State == WebSocketState.Open)
                    {
                        var buffer = Encoding.UTF8.GetBytes(message);
                        var arraySegment = new ArraySegment<byte>(buffer);
                        await client.SendAsync(arraySegment, WebSocketMessageType.Text, true, CancellationToken.None);
                        Console.WriteLine($"Mensagem enviada para o cliente com idOrder {idOrder}: {message}");
                    }
                }
            }
            else
            {
                Console.WriteLine($"Nenhum cliente conectado para o idOrder {idOrder}.");
            }
        }


    }
}
