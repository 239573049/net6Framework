using System;

namespace Util
{
    public class StringUtil
    {
        private static readonly string str= "qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNM1234567890";
        /// <summary>
        /// 获取随机字符串
        /// </summary>
        /// <param name="s">长度</param>
        /// <returns></returns>
        public static string GetString(int s)
        {
            return Guid.NewGuid().ToString();
        }

        /// <summary>
        /// 获取随机字符串异步
        /// </summary>
        /// <param name="s">长度</param>
        /// <returns></returns>
        public static async Task<string> GetStringAsync(int s)
        {
            return await Task.Run(() =>
            {
                return Guid.NewGuid().ToString();
            });
        }
    }
}
