using AbstractMqHelp;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestRabbitMq
{
    public class TestDi
    {
        public TestDi()
        {

        }
        public IPublisher _publisher { get; set; }
        public TestDi(IPublisher publisher)
        {
            this._publisher = publisher;
        }

        public void F1()
        {
            _publisher.Publish("test", "hhhhh");
        }
    }
}
