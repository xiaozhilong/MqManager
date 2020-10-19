using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractMqHelp
{
    /// <summary>
    /// 订阅方法标记的特性
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
    public class MqSubscribeAttribute:Attribute
    {
        public MqSubscribeAttribute(string channel)
        {
            Channel = channel;
        }
        /// <summary>
        /// 通道名
        /// </summary>
        public string Channel { get; set; }
        /// <summary>
        /// 队列名 默认名称是DefaultQueue
        /// </summary>
        public string Queue { get; set; } = "DefaultQueue";
    }
}
