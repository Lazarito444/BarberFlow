using Scalar.AspNetCore;

namespace BarberFlow.Presentation.Api.Extensions;

public static class WebApplicationExtensions
{
    extension(WebApplication app)
    {
        public void UseScalar()
        {
            app.MapScalarApiReference();
        }
    }
}
