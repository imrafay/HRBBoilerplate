namespace HRBBoilerplate.Middleware
{
    public class CustomMiddleware
    {
        private readonly RequestDelegate _next;

        public CustomMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            //TODO
            //Work before next middleware call

            //Call the next middleware
            await _next(context);

            //TODO
            //Work after next middleware call
        }
    }
}
