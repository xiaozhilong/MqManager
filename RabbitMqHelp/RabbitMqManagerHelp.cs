using RabbitMQ.Client;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace RabbitMqHelp
{
    public class RabbitMqManagerHelp : IDisposable
    {
        public RabbitMqManagerHelp()
        {
            //_connection = CreateConnection();
        }
        /// <summary>
        /// 默认15个通道
        /// </summary>
        private const int DefaultPoolSize = 15;
        /// <summary>
        /// 信号量
        /// </summary>
        private readonly SemaphoreSlim _connectionLock = new SemaphoreSlim(initialCount: 2, maxCount: 10);
        private readonly SemaphoreSlim _modelLock = new SemaphoreSlim(initialCount: 10, maxCount: 50);
        /// <summary>
        /// 通道
        /// </summary>
        private readonly ConcurrentQueue<IModel> _pool;
        /// <summary>
        /// 连接
        /// </summary>
        public IConnection _connection;

        /// <summary>
        /// 锁
        /// </summary>
        private static readonly object SLock = new object();

        public IConnection CreateConnection()
        {
            //_connectionLock.Wait();
            if (_connection!= null)
            {
                return _connection;
            }
            _connectionLock.Wait();
            try
            {
                if (_connection == null)
                {
                    var factory = new ConnectionFactory
                    {
                        HostName="localhost",
                        UserName = "admin",
                        Port = 5672,
                        Password = "admin",
                        VirtualHost = "/"
                    };
                    _connection = factory.CreateConnection();
                   
                }
            }
            finally
            {
                _connectionLock.Release();
            }
            return _connection;
        }

        public IModel CreateModel()
        {
            lock (SLock)
            {
                return  _connection.CreateModel();
            }
        }

        public void Dispose()
        {
            //if (_channel != null)
            //{
            //    _channel.Close();
            //}
        }
    }
}
