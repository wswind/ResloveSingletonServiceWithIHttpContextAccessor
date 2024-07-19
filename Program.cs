namespace WebApplication1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();

            builder.Services.AddSingleton<TestService>();

            var testService2 = new TestService2();
            builder.Services.AddSingleton(testService2);

            builder.Services.AddHttpContextAccessor();

            AppService.Services = builder.Services;

            var app = builder.Build();

            AppService.ServiceProvider = app.Services;

            AppService.TestService2 = testService2;

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
