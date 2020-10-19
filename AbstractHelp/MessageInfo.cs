using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractMqHelp
{
    public class MessageInfo
    {
        /// <summary>
        /// 唯一编号
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 是否成功
        /// </summary>
        public bool IsSucceed { get; set; }
        /// <summary>
        /// 发送次数
        /// </summary>
        public int Count { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        public string Content { get; set; }
    }

}
