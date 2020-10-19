using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AbstractMqHelp;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using RabbitMqHelp;

namespace WebApplication1
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddRabbitMqServer(Configuration, steup =>
             {
                 steup.HostName = "localhost";
                 steup.VHost = "/";
                 steup.UserName = "guest";
                 steup.PassWord = "guest";
             });
            //services.AddSingleton<IPublisher, RabbitMQPublisher>();
            services.AddMongoDBServer(Configuration, steup => {
                steup.ConnectionString = "mongodb://127.0.0.1:27017";
                steup.DatabaseName = "TestDb1";
            });
            services.AddSingleton(typeof(IMongoDbBase), typeof(MongoDBBase));

            services.AddSingleton<ITest1, Test1>();
            services.AddScoped<ITest2, Test2>();
            services.AddTransient<ITest3, Test3>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }



    public interface ITest1
    {
        Guid guid { get; set; }
        List<string> GetList();
    }
    public interface ITest2
    {
        Guid guid { get; set; }
        List<string> GetList();
    }

    public interface ITest3
    {
        Guid guid { get; set; }
        List<string> GetList();
    }



    public class Test1 : ITest1
    {
        public Test1()
        {
            guid = Guid.NewGuid();
        }
        public Guid guid { get ; set ; }

        public List<string> GetList()
        {
            return new List<string>() { "LiLei", "ZhangSan", "LiSi" };
        }
    }
    public class Test2 : ITest2
    {
        public Test2()
        {
            guid = Guid.NewGuid();
        }
        public Guid guid { get ; set; }

        public List<string> GetList()
        {
            return new List<string>() { "LiLei", "ZhangSan", "LiSi" };
        }
    }
    public class Test3 : ITest3
    {
        public Test3()
        {
            guid = Guid.NewGuid();
        }
        public Guid guid { get ; set ; }

        public List<string> GetList()
        {
            return new List<string>() { "LiLei", "ZhangSan", "LiSi" };
        }
    }
}
