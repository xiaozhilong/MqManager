using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractMqHelp
{
    /// <summary>
    /// 序列化消息器
    /// </summary>
    public interface IMessageSerializer
    {
        /// <summary>
        /// 序列化消息。
        /// </summary>
        /// <typeparam name="T">消息类型</typeparam>
        /// <param name="message">消息实例</param>
        /// <returns></returns>
        byte[] SerializerBytes<T>(T message) where T : class;

        /// <summary>
        /// 反序列化消息。
        /// </summary>
        /// <typeparam name="T">消息类型</typeparam>
        /// <param name="bytes">bytes</param>
        /// <returns></returns>
        T Deserialize<T>(byte[] bytes) where T : class;
    }
}
