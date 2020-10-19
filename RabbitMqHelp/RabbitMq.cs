using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace AbstractMqHelp
{
    public class RabbitMq : IDisposable
    {

        

        //析构函数
        ~RabbitMq()
        {
            Dispose(disposing: false);
        }
        private static ConnectionFactory _connectionFactory;
        //连接
        private static IConnection _Connection;
        //信道
        private static IModel _Model;

        private bool disposedValue;

        public static string _HostName { get; set; } = "localhost";
        public static string _VHost { get; set; } = "/";
        public static string _UserName { get; set; } = "guest";
        public static string _PassWord { get; set; } = "guest";

        static RabbitMq()
        {
            
            if (_Connection != null) throw new ArgumentException(typeof(RabbitMq).Name, "_Connection");
            //实例化连接工厂
            _connectionFactory = new ConnectionFactory()
            {
                HostName = _HostName,
                VirtualHost = _VHost,
                UserName = _UserName,
                Password = _PassWord
            };
            //创建连接
            _Connection = _connectionFactory.CreateConnection();
            //创建信道
            _Model = _Connection.CreateModel();
        }

        public RabbitMq()
        {

        }
        public RabbitMq(string hostName, string vHost, string userName, string passWord)
        {
            _HostName = hostName;
            _VHost = vHost;
            _UserName = userName;
            _PassWord = passWord;

            //实例化连接工厂
            _connectionFactory = new ConnectionFactory()
            {
                HostName = _HostName,
                VirtualHost = _VHost,
                UserName = _UserName,
                Password = _PassWord
            };
            //创建连接
            _Connection = _connectionFactory.CreateConnection();
            //创建信道
            _Model = _Connection.CreateModel();
        }

        #region Hello_World

        public void HelloWorldSend(string queueName, string message)
        {
            //声明队列
            _Model.QueueDeclare(queue: queueName,
                        durable: false,
                        exclusive: false,
                        autoDelete: false,
                        arguments: null);
            //构建byte消息数据包
            var body = Encoding.UTF8.GetBytes(message);
            //发送数据包
            _Model.BasicPublish(exchange: "",
                                         routingKey: "hello",
                                         basicProperties: null,
                                         body: body);
            Console.WriteLine(" [x] Sent {0}", message);
        }

        public void HelloWorldReceive(string queueName, EventHandler<BasicDeliverEventArgs> eventHandler)
        {
            _Model.QueueDeclare(queue: queueName,
                                durable: false,
                                exclusive: false,
                                autoDelete: false,
                                arguments: null);
            //构造消费者实例
            var consumer = new EventingBasicConsumer(_Model);
            //绑定消息接收后的事件委托
            consumer.Received += eventHandler;
            //启动消费者 自动确定消息
            _Model.BasicConsume(queue: queueName,
                                         autoAck: true,
                                         consumer: consumer);
            Console.WriteLine(" Press [enter] to exit.");
            Console.ReadLine();
        }
        public void MsgEventHandler()
        {
            HelloWorldReceive("hello", (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                Console.WriteLine(" [x] Received {0}", message);
            });
        }
        #endregion

        #region Work Queues


        #endregion


        #region 释放资源
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: 释放托管状态(托管对象)
                    if (_Connection != null)
                    {
                        _Connection.Dispose();
                    }
                    if (_Model != null)
                    {
                        _Model.Dispose();
                    }
                }

                // TODO: 释放未托管的资源(未托管的对象)并替代终结器
                // TODO: 将大型字段设置为 null
                disposedValue = true;
            }
        }

        // // TODO: 仅当“Dispose(bool disposing)”拥有用于释放未托管资源的代码时才替代终结器
        // ~RabbitMq()
        // {
        //     // 不要更改此代码。请将清理代码放入“Dispose(bool disposing)”方法中
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // 不要更改此代码。请将清理代码放入“Dispose(bool disposing)”方法中
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
