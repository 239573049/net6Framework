using System.Data.Common;
using Token.Infrastructure;

namespace Token.EntityFrameworkCore
{
    public class MasterSlaveManager
    {

        private static string[] _config => LoadConfig();

        /// <summary>
        /// 加载主从配置
        /// </summary>
        /// <param name="fileName">配置文件</param>
        /// <returns></returns>
        public static string[] LoadConfig()
        {
            return AppSettings.App("sql").Split("|");
        }

        /// <summary>
        /// 切换到主库
        /// </summary>
        /// <param name="command">DbCommand</param>
        public static void SwitchToMaster(DbCommand command)
        {
            //切换数据库连接
            ChangeDbConnection(command, AppSettings.App("sqlservice"));
        }

        /// <summary>
        /// 切换到从库
        /// </summary>
        /// <param name="command">DbCommand</param>
        public static void SwitchToSlave(DbCommand command, string serverName = "")
        {
            if (_config.Length == 0)
            {
                ChangeDbConnection(command, AppSettings.App("sqlservice"));
                return;
            }
            var r = new Random();
            var connection = _config[r.Next(_config.Length) - 1];
            ChangeDbConnection(command, connection);
        }

        /// <summary>
        /// 切换数据库连接
        /// </summary>
        /// <param name="command"></param>
        /// <param name="dbServer"></param>
        private static void ChangeDbConnection(DbCommand command, string connectionString)
        {
            var conn = command.Connection;
            if (conn.ConnectionString == connectionString) return;
            if (conn.State == System.Data.ConnectionState.Open) conn.Close();
            conn.ConnectionString = connectionString;
            conn.Open();
        }
    }
}
