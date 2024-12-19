

using RestFulAPI.Middleware;

namespace RestFulAPI.Helpers;

public static class CheckIfAuth
{
    public static IApplicationBuilder UseCheckIfAuth(this IApplicationBuilder app)
    {
        return app.UseMiddleware<AddTokenMiddleware>();
    }
}