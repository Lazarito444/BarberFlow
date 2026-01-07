namespace BarberFlow.Presentation.Api.Extensions;

public static class IServiceCollectionExtensions
{
    extension(IServiceCollection services)
    {
        public void SetupOpenApi()
        {
            services.AddOpenApi();
        }
    }
}
