using AbstractMqHelp;
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace RabbitMqHelp
{
    public class ProtobufMessageSerializer : IMessageSerializer
    {
        public T Deserialize<T>(byte[] bytes) where T : class
        {
            using (MemoryStream ms = new MemoryStream(bytes))
            {
                T t=Serializer.Deserialize<T>(ms);
                return t;
            }
        }

        public byte[] SerializerBytes<T>(T message) where T : class
        {
            using (MemoryStream ms = new MemoryStream())
            {
                Serializer.Serialize<T>(ms, message);
                Console.WriteLine(ms.ToArray().Length);
                return ms.ToArray();
            }
        }
    }
}
