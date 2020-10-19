using Apache.NMS;
using Apache.NMS.ActiveMQ.Commands;
using AbstractMqHelp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ActiveMqHelp
{
    public class Publisher : IPublisher
    {
        public IConnectionFactory _IConnectionFactory { get; set; }
        /// <summary>
        /// 链接
        /// </summary>
        public IConnection _IConnection { get; set; }
        /// <summary>
        /// 会话
        /// </summary>
        public ISession _ISession { get; set; }



        public void Publish<T>(string channelName, T message) where T : class
        {
            var producer=_ISession.CreateProducer(new ActiveMQTopic(channelName));
            ITextMessage msg = producer.CreateTextMessage();
            msg.Text =Encoding.UTF8.GetString(MessageSerializerFactory.CreateMessageSerializerInstance().SerializerBytes(message));
            producer.Send(msg, MsgDeliveryMode.Persistent, MsgPriority.Normal, TimeSpan.MinValue);
        }

        public void Publish(string channelName, string message)
        {
            throw new NotImplementedException();
        }

        public Task PublishAsync<T>(string channelName, T message) where T : class
        {
            throw new NotImplementedException();
        }
    }
}
