using System.Net;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Hosting;

namespace ctest
{
	public class Program
	{
		public static void Main(string[] args)
		{
			CreateHostBuilder(args).Build().Run();
		}

		public static IHostBuilder CreateHostBuilder(string[] args)
		{
			return Host.CreateDefaultBuilder(args).ConfigureWebHostDefaults(delegate (IWebHostBuilder webBuilder)
			{
				webBuilder
				.UseStartup<Startup>()
                //.UseKestrel(delegate (KestrelServerOptions options)
                //{
                //    options.Listen(IPAddress.Any, 7000, delegate (ListenOptions listenOptions)
                //    {
                //        listenOptions.UseHttps("ctest.pfx", "ga700807");
                //    });
                //});
                .UseUrls("http://*:5000");
            });
		}
	}
}
