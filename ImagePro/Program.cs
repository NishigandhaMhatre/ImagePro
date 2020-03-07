using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace ImagePro
{
    class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseKestrel(opt => opt.AddServerHeader = false)
                .UseStartup<Startup>();
    }
}
