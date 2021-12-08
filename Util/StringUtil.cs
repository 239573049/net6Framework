namespace Util
{
    public class StringUtil
    {
        /// <summary>
        /// 获取随机字符串
        /// </summary>
        /// <param name="s">长度</param>
        /// <returns></returns>
        public static string? GetString(int s)
        {
            string? data = null;
            var chats = new char[] {'q','w','e','r','t','y','u','i','o','p','a','s','d','f','g','h','j','k','l','z','x','c','v','b','n','m','Q','W','E','R','T','Y','U','I','O','P','A','S','D','F','G','H','J','K','L','Z','X','C','V','B','N','M','1','2','3','4','5','6','7','8','9','0' };
            for (int i = 0; i < s; i++)
            {
                data+=chats[new Random().Next(chats.Length-1)];
            }
            return data;
        }

        /// <summary>
        /// 获取随机字符串异步
        /// </summary>
        /// <param name="s">长度</param>
        /// <returns></returns>
        public static async Task<string?> GetStringAsync(int s)
        {
            return await Task.Run(() =>
            {

                string? data = null;
                var chats = new char[] { 'q', 'w', 'e', 'r', 't', 'y', 'u', 'i', 'o', 'p', 'a', 's', 'd', 'f', 'g', 'h', 'j', 'k', 'l', 'z', 'x', 'c', 'v', 'b', 'n', 'm', 'Q', 'W', 'E', 'R', 'T', 'Y', 'U', 'I', 'O', 'P', 'A', 'S', 'D', 'F', 'G', 'H', 'J', 'K', 'L', 'Z', 'X', 'C', 'V', 'B', 'N', 'M', '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' };
                for (int i = 0; i < s; i++)
                {
                    data += chats[new Random().Next(chats.Length - 1)];
                }
                return data;
            });
        }
    }
}
