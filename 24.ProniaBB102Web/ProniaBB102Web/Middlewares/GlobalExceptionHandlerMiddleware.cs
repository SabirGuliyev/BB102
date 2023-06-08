namespace ProniaBB102Web.Middlewares
{
    public class GlobalExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public GlobalExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {

            try
            {
                await _next.Invoke(context);
            }
            catch (Exception ex)
            {
                HandleException(context, ex);
               
            }
        }

        public void HandleException(HttpContext context,Exception exception)
        {
            context.Response.Redirect($"/Home/ErrorPage?errorMessage={exception.Message}");
        }
    }
}
