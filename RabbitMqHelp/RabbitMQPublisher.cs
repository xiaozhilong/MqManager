using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using RabbitMqHelp;

namespace AbstractMqHelp
{
    public class RabbitMQPublisher : IPublisher
    {
        //private readonly RabbitMQProvider _provider;
        //private IConnection _connection;
        //public RabbitMQPublisher(RabbitMQProvider provider)
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
        //    if (Channel != null)
        //    {
        //        if (Channel.IsOpen)
        //            Channel.Close();
        //        Channel.Abort();
        //        Channel.Dispose();
        //    }

        //    if (Connection != null)
        //    {
        //        if (Connection.IsOpen)
        //            Connection.Close();
        //    }
        //}
        //private readonly IModel _Channel;
        private readonly IConnection _connection;
        private readonly IModel _model;
        private readonly IMongoDbBase _mongoDbBase;


        public RabbitMQPublisher(IConnection connection, IMongoDbBase mongoDbBase)
        {
            this._connection = connection;
            this._mongoDbBase = mongoDbBase;
        }

        public void Publish<T>(T message) where T : class
        {
            var channelName = typeof(T).Name;
            using (var _Channel=_connection.CreateModel())
            {
                _Channel.ExchangeDeclare(exchange: channelName, type: "fanout", durable: false, autoDelete: false, null);
                _Channel.BasicPublish
                (
                      exchange: channelName,
                      routingKey: string.Empty,
                      mandatory: false,
                      basicProperties: null,
                      body: RabbitMqHelp.MessageSerializerFactory.CreateMessageSerializerInstance().SerializerBytes(message)
                );
            }
            //_Channel.ExchangeDeclare(exchange: channelName, type: "fanout", durable: false, autoDelete: false,null);
            //_Channel.BasicPublish
            //(
            //      exchange: channelName,
            //      routingKey: string.Empty,
            //      mandatory: false,
            //      basicProperties: null,
            //      body: RabbitMqHelp.MessageSerializerFactory.CreateMessageSerializerInstance().SerializerBytes(message)
            //);
        }

        public void Publish(string message, string channelName)
        {
          //  _Channel.ExchangeDeclare(exchange: channelName, type: "fanout", durable: false, autoDelete: false, null);


          //  _Channel.BasicPublish
          //(
          //                 exchange: channelName,
          //                 routingKey: string.Empty,
          //                 mandatory: false,
          //                 basicProperties: null,
          //                 body: RabbitMqHelp.MessageSerializerFactory.CreateMessageSerializerInstance().SerializerBytes(message)
          //);

        }

        //public Task PublishAsync<T>(T message) where T : class
        //{
        //    return Task.Run(() =>
        //    {
        //        var channelName = typeof(T).Name;
        //        _Channel.ExchangeDeclare(exchange: channelName, type: "fanout", durable: false, autoDelete: false, null);
        //        var msgContent = JsonConvert.SerializeObject(message);
        //        var msgByte = Encoding.UTF8.GetBytes(msgContent);
        //        _Channel.BasicPublish
        //      (
        //                       exchange: channelName,
        //                       routingKey: string.Empty,
        //                       mandatory: false,
        //                       basicProperties: null,
        //                       body: msgByte
        //      );
        //    });
        //}

        public void Publish<T>(string channelName, T message) where T : class
        {
            var id = Guid.NewGuid().ToString("N");
            var DateTimeString = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss zzz");
            Dictionary<string, object> keyValues = new Dictionary<string, object>();
            keyValues.Add("msg-id", id);
            keyValues.Add("msg-type", typeof(T).Name);
            keyValues.Add("msg-senttime", DateTimeString);
            //keyValues.Add("msg-serializerType", "json");
            using (var _Channel = _connection.CreateModel())
            {
                _Channel.ExchangeDeclare(exchange: this.GetType().Assembly.GetName().Name, type: "direct", durable: true, autoDelete: false, arguments: null);
                var properties = _Channel.CreateBasicProperties();
                //设置头文件信息可以方便查找数据
                properties.Headers = keyValues;
                //properties.ContentType = "application/json";
                //properties.ContentEncoding = "utf-8";
                //properties.ReplyTo = "ssss";
                var messgae111 = JsonConvert.SerializeObject(message);
                properties.Persistent = true;
                _Channel.BasicPublish(exchange: this.GetType().Assembly.GetName().Name,
                         routingKey: channelName,
                         basicProperties: properties,
                         body: RabbitMqHelp.MessageSerializerFactory.CreateMessageSerializerInstance().SerializerBytes(message));
                List<MessageInfo1> messageInfos = new List<MessageInfo1>();
                Dictionary<string, object> keyValues1 = new Dictionary<string, object>();
                keyValues1.Add("msg-id", id);
                keyValues1.Add("msg-type", typeof(T).Name);
                keyValues1.Add("msg-senttime", DateTimeString);
                keyValues1.Add("value", messgae111);
                messageInfos.Add(new MessageInfo1
                {
                    Id = id,
                    Content = keyValues1
                });
                var installData = new AbstractMqHelp.MessageInfo
                {
                    Id = id,
                    Count = 1,
                    IsSucceed = true,
                    Content = JsonConvert.SerializeObject(new { Headers = keyValues, Value = messgae111 })
                };
                
                var ss = _mongoDbBase.InsertManyAsync<MessageInfo1>(messageInfos);





                ////创建队列 持久化队列
                //Channel.QueueDeclare(queue: channelName, durable: true, exclusive: false, autoDelete: false, arguments: null);
                ////将消息标记为持久性 - 将IBasicProperties.SetPersistent设置为true
                //var properties = Channel.CreateBasicProperties();
                //properties.Persistent = true;
            }
        }

        public Task PublishAsync<T>(string channelName, T message) where T : class
        {
            throw new NotImplementedException();
        }
    }

    public enum SerializerType
    {
        json,
        protobuf
    }

    public class MessageInfo1
    {
        /// <summary>
        /// 编号
        /// </summary>
        public string Id { get; set; }

        public Dictionary<string, object> Content { get; set; }

        public DateTime CreateTime { get; set; } = DateTime.Now;
    }
}
