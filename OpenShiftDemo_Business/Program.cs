using Serilog;

namespace OpenShiftDemo_Business
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            #region Configurations

            builder.Host.ConfigureAppConfiguration((ctx, builder) =>
            {
                builder.AddJsonFile("appsettings.json");
                builder.AddJsonFile("conf/appsettings.json", optional: true, reloadOnChange: true);
                builder.AddJsonFile("secret/secret.json", optional: true, reloadOnChange: true);
            });

            #endregion

            #region SeriLog

            var config = new ConfigurationBuilder()
                .AddJsonFile("SeriLogConf.json")
                .Build();

            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(config)
                .CreateLogger();

            builder.Host.UseSerilog();

            #endregion

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}