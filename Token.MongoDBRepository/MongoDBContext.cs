using MongoDB.Driver;
using Token.Infrastructure;

namespace MongoDBRepository.Repositorys;
public class MongoDBContext : MongoClient
{
    /// <summary>
    /// 连接字符串
    /// </summary>
    public static string? ConnectionString { get { return AppSettings.App("mongodb"); }} 
    public MongoDBContext(
        ) : base(ConnectionString)
    {
    }
}