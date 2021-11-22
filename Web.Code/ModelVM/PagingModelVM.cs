namespace Web.Code.ModelVM
{
    public class PagingModelVM<T>
    {
        public int Count { get; set; }
        public T Data { get; set; }
        public PagingModelVM(T data,int count)
        {
            Data = data;
            Count = count;
        }
    }
}
