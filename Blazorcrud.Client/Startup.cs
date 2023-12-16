using Blazorcrud.Client.Services;

namespace Blazorcrud.Client
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            
            services.AddSingleton<ExportService>();
        }
    }
}