using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AbstractMqHelp;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProtoBuf;
using RabbitMqHelp;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IPublisher _publisher;
        private readonly ISubscriber _subscriber;
        private readonly IMongoDbBase _mongoDbBase;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IPublisher publisher, ISubscriber subscriber, IMongoDbBase mongoDbBase)
        {
            _logger = logger;
            _publisher = publisher;
            _subscriber = subscriber;
            _mongoDbBase = mongoDbBase;
        }

        [HttpGet]
        public IActionResult Get()
        {
            //var rng = new Random();
            //var sss= Enumerable.Range(1, 5).Select(index => new WeatherForecast
            //{
            //    Date = DateTime.Now.AddDays(index),
            //    TemperatureC = rng.Next(-20, 55),
            //    Summary = Summaries[rng.Next(Summaries.Length)]
            //})
            //.ToArray();
            //List<Person> person = new List<Person>();
            //for (int i = 0; i < 1000; i++)
            //{
            //    person.Add(new Person
            //    {
            //        Id = i,
            //        Name = $"肖志龙_{i}"
            //    });
            //    _publisher.Publish("jsonmsginfo", person);
            //}
            ////_publisher.Publish("jsonmsginfo", person);
            //return person;
            return Ok();
        }
        [HttpGet]
        public void Msg()
        {
            _subscriber.Subscribe("jsonmsginfo", "JsonQueueDemo1", msgBytes =>
                 {
                     //var result = MessageSerializerFactory.CreateMessageSerializerInstance().Deserialize<Person>(msgBytes);
                     Console.WriteLine(msgBytes);
                 });
        }
        [HttpGet]
        public IActionResult Send()
        {
            //List<Person> person = new List<Person>();
            for (int i = 0; i < 1000; i++)
            {
                //person.Add(new Person
                //{
                //    Id = i,
                //    Name = $"肖志龙_{i}"
                //});
                var person = new Person
                {
                    Id=i,
                    Name=$"xzl_{i}"
                };
                _publisher.Publish("jsonmsginfo", person);
            }
            //_publisher.Publish("jsonmsginfo", person);
            return Ok();
        }

        [HttpGet]
        public async Task<IEnumerable<MessageInfo>> GetMessage(string id)
        {
            return await _mongoDbBase.GetIEnumerableAsync<MessageInfo>(e=>e.Id == id);
        }

    }

    [ProtoContract]
    public class Person
    {
        [ProtoMember(1)]
        public int Id { get; set; }
        [ProtoMember(2)]
        public string Name { get; set; }
    }
}
