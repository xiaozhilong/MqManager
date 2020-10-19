using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AbstractMqHelp
{
    /// <summary>
    /// 操作数据库接口 提供插入和查询
    /// </summary>
    public interface IDatabaseOperation
    {
        /// <summary>
        /// 插入数据
        /// </summary>
        /// <param name="messageInfo"></param>
        /// <returns></returns>
        int Install<T>(MessageInfo messageInfo);
        /// <summary>
        /// 插入数据
        /// </summary>
        /// <param name="messageInfo"></param>
        /// <returns></returns>
        Task<int> InstallAsync<T>(MessageInfo messageInfo);
        /// <summary>
        /// 通过编号查找数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        MessageInfo GetMessageInfoById<T>(int id);
        /// <summary>
        /// 通过编号查找数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<MessageInfo> GetMessageInfoByIdAsync<T>(int id);
    }
}
