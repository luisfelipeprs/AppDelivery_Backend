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
        if (context.WebSockets.IsWebSocketRequest)
        {
            var webSocket = await context.WebSockets.AcceptWebSocketAsync();
            await useCase.HandleWebSocketConnection(webSocket);
        }
        else
        {
            await _next(context);
        }
    }
}
