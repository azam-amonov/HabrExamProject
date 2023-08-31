namespace Habr.Service.Service.Helpers;

public class Response<T> 
{
    public int StatusCode { get; set; }
    public string Message { get; set; }
    public T Data { get; set; }

    public override string ToString()
    {
        return $"StatusCode: {StatusCode}\n" +
               $"Message: {Message}\n" +
               $"Data: {Data}";
    }
}