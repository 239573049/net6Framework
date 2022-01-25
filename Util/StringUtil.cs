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
            string data = "";
            var random = new Random();
            for (int i = 0; i < s; i++)
            {
                data += str[random.Next(str.Length - 1)];
            }
            return data;
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

                string data = "";
                var random= new Random();
                for (int i = 0; i < s; i++)
                {
                    data += str[random.Next(str.Length - 1)];
                }
                return data;
            });
        }
    }
}
