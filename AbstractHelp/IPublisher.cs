using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AbstractMqHelp
{
    /// <summary>
    /// 发布者
    /// </summary>
    public interface IPublisher
    {
        /// <summary>
        /// 发布
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="channelName">主题名</param>
        /// <param name="message">发送的消息</param>
        void Publish<T>(string channelName, T message) where T : class;
        /// <summary>
        /// 发布
        /// </summary>
        /// <param name="channelName">主题名</param>
        /// <param name="message">发送的消息</param>
        void Publish(string channelName, string message);

        /// <summary>
        /// 异步发布
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="channelName">主题名</param>
        /// <param name="message">发送的消息</param>
        /// <returns></returns>
        Task PublishAsync<T>(string channelName, T message) where T : class;
    }
}
