using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AbstractMqHelp
{
    public class RabbitMQSubscriber : ISubscriber
    {
        //private readonly RabbitMQProvider _provider;
        //private IConnection _connection;
        //public RabbitMQSubscriber(RabbitMQProvider provider)
        //{
        //    _provider = provider;
        //    _connection = _provider.ConnectionFactory.CreateConnection();
        //}

        //public IConnection Connection
        //{
        //    get
        //    {
        //        if (_connection != null)
        //            return _connection;
        //        return _connection = _provider.ConnectionFactory.CreateConnection();
        //    }
        //}

        //private IModel _channel;
        //public IModel Channel
        //{
        //    get
        //    {
        //        if (_channel != null)
        //            return _channel;
        //        else
        //            return _channel = _connection.CreateModel();
        //    }
        //}


        //public void Dispose()
        //{
        //    if (_channel != null)
        //    {
        //        _channel.Abort();
        //        if (_channel.IsOpen)
        //            _channel.Close();

        //        _channel.Dispose();
        //    }

        //    if (_connection != null)
        //    {
        //        if (_connection.IsOpen)
        //            _connection.Close();

        //        _connection.Dispose();
        //    }
        //}


        //private readonly IModel _Channel;
        private readonly IConnection _connection;
        public RabbitMQSubscriber(IConnection connection)
        {
            _connection = connection;
        }

        /// <summary>
        /// 消费消息，并执行回调。
        /// </summary>
        /// <param name="channelName"></param>
        /// <param name="callback"></param>
        public void Subscribe(string channelName,string group, Action<byte[]> callback)
        {
            var _Channel = _connection.CreateModel();


                //声明交换机
                _Channel.ExchangeDeclare(exchange: this.GetType().Assembly.GetName().Name, type: "direct", durable: true, autoDelete: false, arguments: null);
                //消息队列名称
                //var queueName = channelName + "_" + Guid.NewGuid().ToString("N");
                //声明队列
                _Channel.QueueDeclare(queue: group, durable: true, exclusive: false, autoDelete: false, arguments: null);
                var properties = _Channel.CreateBasicProperties();
                properties.Persistent = true;
                //将队列与交换机进行绑定
                _Channel.QueueBind(queue: group, exchange: this.GetType().Assembly.GetName().Name, routingKey: channelName);
                //声明为手动确认，每次只消费1条消息。
                _Channel.BasicQos(0, 1, false);
                //定义消费者
                var consumer = new EventingBasicConsumer(_Channel);
                //接收事件
                consumer.Received += (eventSender, args) =>
                {
                    var message = args.Body.ToArray();//接收到的消息

                callback(message);
                //返回消息确认
                _Channel.BasicAck(args.DeliveryTag, true);
                };
                //开启监听
                _Channel.BasicConsume(queue: group, autoAck: false, consumer: consumer);
            

        }

        public Task<T> SubscribeAsync<T>(string channelName) where T : class
        {
            throw new NotImplementedException();
        }

        public void Subscribe(string channelName, Action<string> callback)
        {
            throw new NotImplementedException();
        }

        public void Subscribe<T>(string channelName, Action<T> callback) where T : class
        {
            throw new NotImplementedException();
        }

        public Task<T> SubscribeAsync<T>(string channelName, Action<T> callback) where T : class
        {
            throw new NotImplementedException();
        }
    }
}
