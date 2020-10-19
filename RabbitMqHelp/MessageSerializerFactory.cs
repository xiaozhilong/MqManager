using AbstractMqHelp;
using System;
using System.Collections.Generic;
using System.Text;

namespace RabbitMqHelp
{
    public class MessageSerializerFactory
    {
        /// <summary>
        /// 创建一个消息序列化组件
        /// </summary>
        /// <returns></returns>
        public static IMessageSerializer CreateMessageSerializerInstance()
        {
            return new ProtobufMessageSerializer();
        }
    }
}
