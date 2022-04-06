namespace Token.Application
{
    public interface IDataService 
    {
        List<string> GetData();
    }
    public class DataService : IDataService
    {
        public List<string> GetData()
        {
            var data = new List<string>
            {
                "测试数据",
                "测试数据1",
                "测试数据2",
                "测试数据3",
                "测试数据4",
                "测试数据5",
                "测试数据6"
            };
            return data;  
        }
    }
}