using System;
using System.Collections.Generic;
using System.Text;

namespace RabbitMqHelp
{
    /// <summary>
    /// RabbitMq配置
    /// </summary>
    public class RabbitMqConfigInfo
    {
        /// <summary>
        /// 地址
        /// </summary>
        public  string HostName { get; set; } = "localhost";
        /// <summary>
        /// 
        /// </summary>
        public  string VHost { get; set; } = "/";
        /// <summary>
        /// 用户名
        /// </summary>
        public  string UserName { get; set; } = "guest";
        /// <summary>
        /// 密码
        /// </summary>
        public  string PassWord { get; set; } = "guest";
    }
}
