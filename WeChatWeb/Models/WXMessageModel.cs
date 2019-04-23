using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeChatWeb.Models
{
    public class WXMessageModel
    {

    }
    /// <summary>
    /// 文本消息
    /// </summary>
    public class TextMessageModel
    {
        /// <summary>
        /// 开发者微信号
        /// </summary>
        public string ToUserName { get; set; }
        /// <summary>
        /// 发送方帐号（一个OpenID）
        /// </summary>
        public string FromUserName { get; set; }
        /// <summary>
        /// 消息创建时间 （整型）
        /// </summary>
        public int CreateTime { get; set; }
        /// <summary>
        /// 消息类型，文本为text
        /// </summary>
        public string MsgType { get; set; }
        /// <summary>
        /// 文本消息内容
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// 消息id
        /// </summary>
        public long MsgId { get; set; }
    }
}
