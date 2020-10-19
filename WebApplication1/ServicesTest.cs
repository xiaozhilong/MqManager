using AbstractMqHelp;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1
{
    public class ServicesTest : ISubscriberService,ISubscribeBase
    {
        [MqSubscribe("mqtest")]
        public void CheckReceivedMessage<T>(T t)
        {
            Console.WriteLine(JsonConvert.SerializeObject(t));
        }
    }
    public interface ISubscriberService
    {
        public void CheckReceivedMessage<T>(T t);
        
    }
}
