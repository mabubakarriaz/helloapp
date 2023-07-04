namespace hello_app_web
{
    public class Program
    { //test
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            // Load JSON file based on the environment value
            string environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            string jsonFileName = $"appsettings.{environment}.json";

            builder.Configuration
                .SetBasePath(builder.Environment.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile(jsonFileName, optional: true, reloadOnChange: true)
                .Build();

            // Add services to the container.
            builder.Services.AddRazorPages();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapRazorPages();

            app.Run();
        }
    }
}