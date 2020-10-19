using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractMqHelp
{
    /// <summary>
    /// 序列化工厂
    /// </summary>
    public class MessageSerializerFactory
    {
        /// <summary>
        /// 创建一个消息序列化组件 默认json序列化
        /// </summary>
        /// <returns></returns>
        public static IMessageSerializer CreateMessageSerializerInstance()
        {
            return new JsonMessageSerializer();
        }
    }
}
