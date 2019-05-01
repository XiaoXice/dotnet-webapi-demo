using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace dotnet_webapi_1
{
    /// <summary>
    /// 主类
    /// </summary>
    public class Program
    {
        /// <summary>
        /// 启动方法
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }
        /// <summary>
        /// WebHost的构建函数
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
