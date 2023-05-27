namespace WebAPI.Middleware
{
    public class BodyMiddleware
    {
        private readonly RequestDelegate _next;

        public BodyMiddleware(RequestDelegate next)
        {
            _next = next;
        }


        public async Task Invoke(HttpContext context)
        {
            context.Request.EnableBuffering();

            using var reader = new StreamReader(context.Request.Body, leaveOpen: true);
            var body = await reader.ReadToEndAsync();

            Console.WriteLine($"Body da requisição: {body}");

            context.Request.Body.Seek(0, SeekOrigin.Begin);

            await _next(context);


            context.Response.Body.Seek(0, SeekOrigin.Begin);

            var retorno = await new StreamReader(context.Response.Body).ReadToEndAsync();

            Console.WriteLine($"retorno da requisição: {body}");
        }
    }
}
