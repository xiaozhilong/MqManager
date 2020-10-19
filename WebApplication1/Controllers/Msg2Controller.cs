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
    public class Msg2Controller : ControllerBase
    {
        public Msg2Controller(ITest1 test1,ITest2 test2,ITest3 test3)
        {
            Test1 = test1;
            Test2 = test2;
            Test3 = test3;
        }

        public ITest1 Test1 { get; }
        public ITest2 Test2 { get; }
        public ITest3 Test3 { get; }

        [HttpGet]
        public IEnumerable<Guid> Send()
        {
            List<Guid> guids = new List<Guid> { Test1.guid,Test2.guid,Test3.guid };
            return guids;
        }

        [HttpGet]
        public IActionResult Receive()
        {
            return Ok();
        }
    }

   
}
