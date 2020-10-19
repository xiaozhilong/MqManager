using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractMqHelp
{
    /// <summary>
    /// json序列化
    /// </summary>
    public class JsonMessageSerializer : IMessageSerializer
    {
        public T Deserialize<T>(byte[] bytes) where T : class
        {
            return JsonConvert.DeserializeObject<T>(Encoding.UTF8.GetString(bytes));
        }

        public byte[] SerializerBytes<T>(T message) where T : class
        {
            Console.WriteLine(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(message)).Length);
            return Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(message));
        }
    }
}
