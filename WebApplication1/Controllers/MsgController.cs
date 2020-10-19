using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AbstractMqHelp;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    /// <summary>
    /// 模拟测试 消息
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MsgController : ControllerBase
    {
        public MsgController(IPublisher publisher, ISubscriber subscriber)
        {
            Publisher = publisher;
            Subscriber = subscriber;
        }

        public IPublisher Publisher { get; }
        public ISubscriber Subscriber { get; }

        [HttpGet]
        public IActionResult Send(int id)
        {
            Publisher.Publish<MsgInfo>("mqtest", new MsgInfo { Id=id});
            return Ok();
        }

        [HttpGet]
        public IActionResult Receive()
        {
            Subscriber.Subscribe("mqtest", "TestDemo1", msg =>
            {
                Console.WriteLine(msg.Length);
            });
            return Ok();
        }
    }


   
     internal class MsgInfo
    {
        public int Id { get; set; }
    }
}
