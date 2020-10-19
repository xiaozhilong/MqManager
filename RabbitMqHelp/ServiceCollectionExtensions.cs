using AbstractMqHelp;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace RabbitMqHelp
{
    /// <summary>
    /// 对IService的扩展
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// 自定义配置
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <param name="steup"></param>
        public static void AddRabbitMqServer(this IServiceCollection services, IConfiguration configuration,Action<RabbitMqConfigInfo> steup)
        {
            services.Configure(steup);
            services.Configure<RabbitMqConfigInfo>(options =>
            {
                configuration.GetSection("RabbitMqOptions").Bind(options);
            });
            services.AddSingleton<IConnection>(sp =>
            {
                var options = sp.GetService<IOptions<RabbitMqConfigInfo>>()?.Value ?? throw new ArgumentNullException(nameof(RabbitMqConfigInfo));
                return new ConnectionFactory()
                {
                    HostName = options.HostName,
                    VirtualHost = options.VHost,
                    UserName = options.UserName,
                    Password = options.PassWord
                }
                .CreateConnection();               
            });
            services.AddSingleton<IPublisher,RabbitMQPublisher>();
            services.AddSingleton<ISubscriber, RabbitMQSubscriber>();
        }
        /// <summary>
        /// 配置1
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        public static void AddRabbitMqServer(this IServiceCollection services,IConfiguration configuration)
        {
            services.Configure<RabbitMqConfigInfo>(options=>
            {
                configuration.GetSection("RabbitMqOptions").Bind(options);
            });
            services.AddSingleton<IModel>(sp =>
            {
                var options = sp.GetService<IOptions<RabbitMqConfigInfo>>()?.Value ?? throw new ArgumentNullException(nameof(RabbitMqConfigInfo));
                return new ConnectionFactory()
                {
                    HostName = options.HostName,
                    VirtualHost = options.VHost,
                    UserName = options.UserName,
                    Password = options.PassWord
                }
                .CreateConnection()
                .CreateModel();
            });
        }
    }
}
