namespace OpenShiftDemo_Business
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            #region Get Configurations with.NetLogger

            builder.Host.ConfigureAppConfiguration((ctx, builder) =>
            {
                builder.AddJsonFile("appsettings.json");
                builder.AddJsonFile("conf/appsettings.json", optional: true, reloadOnChange: true);
                builder.AddJsonFile("secret/secret.json", optional: true, reloadOnChange: true);
            });

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