using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace WeChatLib
{
    public class WeChatMsgCrypt
    {
        /// <summary>
        /// 验证微信连接有效性
        /// </summary>
        /// <param name="token"></param>
        /// <param name="signature"></param>
        /// <param name="timestamp"></param>
        /// <param name="nonce"></param>
        /// <returns></returns>
        public static bool VerifySignature(string token, string signature, string timestamp, string nonce)
        {
            bool isVerify = false;
            try
            {
                List<string> list = new List<string>();
                list.Add(token);
                list.Add(timestamp);
                list.Add(nonce);
                list.Sort();
                string toSha = "";
                foreach (var item in list)
                {
                    toSha += item;
                }
                var buffer = Encoding.UTF8.GetBytes(toSha);
                var shaData = SHA1.Create().ComputeHash(buffer);
                var enText = new StringBuilder();
                foreach (byte iByte in shaData)
                {
                    enText.AppendFormat("{0:x2}", iByte);
                }
                var shaStr = enText.ToString();
                LogRecord.writeLogsingle("WeChatMsgCrypt", shaStr);
                if (shaStr == signature)
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                LogRecord.writeLogsingle("WeChatMsgCryptError", ex.ToString());
            }
            return isVerify;
        }

    }
}
