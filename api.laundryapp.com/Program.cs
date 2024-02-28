using LaundryApp.Data;
using LaundryApp.Services;
using LaundryApp.Services.PickupService;

namespace api.laundryapp.com
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllers();

            builder.Services.AddDbContext<LaundryAppContext>();

            //Dependency for Cutomer Access Service
            builder.Services.AddScoped<ICustomerAccessService, CustomerAccessService>();
            builder.Services.AddScoped<IPickupRequestService,PickupRequestService>();

            var app = builder.Build();

            app.UseRouting();
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

            app.Run();
        }
    }
}
