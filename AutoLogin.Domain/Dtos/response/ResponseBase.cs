namespace AutoLogin.Domain.Dtos.response
{
    public class ResponseBase<T>
    {
        public T? Data {  get; set; }
        public int StatusCode { get; set; }
        public string Message { get; set; }
    }
}
