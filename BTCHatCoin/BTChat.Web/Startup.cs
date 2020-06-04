using AoteNiu;
using AoteNiu.Data;
using AoteNiu.Framework;
using AoteNiu.Service;
using Autofac;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using MongoDB.Driver;
using Quartz.Spi;
using System.Linq;
using System.Net;
using System.Text;

namespace BTChat.Web
{
    public class Startup
    {
        private readonly ILogger _log;

        public Startup(IConfiguration configuration, ILogger<Startup> logger)
        {
            this._log = logger;
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddMemoryCache();

            // 自定义内置的参数检查结果返回
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = (context) =>
                {
                    var errors = context.ModelState.Values.SelectMany(x => x.Errors.Select(p => p.ErrorMessage)).ToList();
                    return new JsonResult(new { code = 3006, msg = "invalid parameters", data = errors });
                };
            });

            // Quartz jobs register
            services.AddTransient<CoinPriceJobService>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            loggerFactory.AddLog4Net();

            // Session必须在MVC之前
            //app.UseSession();
            app.UseMvc();

            // Quartz
            app.UseQuartz((quartz) =>
            {
                if (Configuration.GetValue<bool>("AllowQuartzJob"))
                {
                    quartz.AddJob<CoinPriceJobService>("CoinPriceJob", "CoinPriceJobGroup", 600);
                }
            });

            // https请求时，一定要注意协议版本号的问题。否则会报错远程主机关闭连接。
            ServicePointManager.DefaultConnectionLimit = 200;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
        }

        // ConfigureContainer is where you can register things directly
        // with Autofac. This runs after ConfigureServices so the things
        // here will override registrations made in ConfigureServices.
        // Don't build the container; that gets done for you. If you
        // need a reference to the container, you need to use the
        // "Without ConfigureContainer" mechanism shown later.
        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule(new AutofacModule());

            var registrar = new DependencyRegistrar();
            registrar.Register(builder);
        }

    }
}
