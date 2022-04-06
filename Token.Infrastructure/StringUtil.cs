using System;

namespace Token.Infrastructure
{
    public class StringUtil
    {
        /// <summary>
        /// 获取随机字符串
        /// </summary>
        /// <param name="s">长度</param>
        /// <returns></returns>
        public static string GetString(int s)
        {
            return Guid.NewGuid().ToString("N");
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
                return Guid.NewGuid().ToString("N");
            });
        }
    }
}
