using AppDelivery.Application.UseCases.WebSocketTrackingDelivery;

public class WebSocketMiddleware
{
    private readonly RequestDelegate _next;

    public WebSocketMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context, IWebSocketTrackingDeliveryUseCase useCase)
    {
        // Extrair o idOrder do contexto, por exemplo, da URL ou da query string
        var orderId = context.Request.RouteValues["orderId"]?.ToString();

        if (context.WebSockets.IsWebSocketRequest && !string.IsNullOrEmpty(orderId))
        {
            var webSocket = await context.WebSockets.AcceptWebSocketAsync();
            await useCase.HandleWebSocketConnection(webSocket, orderId); // Passa o orderId aqui
        }
        else
        {
            await _next(context);
        }
    }
}
