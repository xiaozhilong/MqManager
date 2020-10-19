using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AbstractMqHelp
{
    public interface ISubscriber: ISubscribeBase
    {
        /// <summary>
        /// 订阅
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="channelName">主题名</param>
        /// <param name="callback">回调函数</param>
        void Subscribe<T>(string channelName, Action<T> callback) where T : class;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="channelName"></param>
        /// <param name="group"></param>
        /// <param name="callback"></param>
        void Subscribe(string channelName, string group, Action<byte[]> callback);
        /// <summary>
        /// 异步订阅
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="channelName"></param>
        /// <returns></returns>
        Task<T> SubscribeAsync<T>(string channelName, Action<T> callback) where T : class;

    }
}
