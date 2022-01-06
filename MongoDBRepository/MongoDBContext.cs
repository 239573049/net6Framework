using MongoDB.Driver;
using Util;

namespace MongoDBRepository.Repositorys;
public class MongoDBContext : MongoClient
{

    /// <summary>
    /// 连接字符串
    /// </summary>
    private static string? ConnectionString { get { return AppSettings.App("mongodb"); }} 
    public MongoDBContext(
        ) : base(ConnectionString)
    {

    }
}