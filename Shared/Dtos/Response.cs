using System.Text.Json.Serialization;

namespace Shared.Dtos
{
    public class Response<T>
    {
        public T Data { get; set; }
        public int StatusCode { get; set; }
        public ErrorDto Error { get; set; }
        [JsonIgnore]
        public bool IsSuccess { get; set; }


        public static Response<T> Success(T data, int statusCode) 
        {
            return new Response<T> { Data = data, StatusCode = statusCode,IsSuccess=true };
        }
        public static Response<T> Success(int statusCode)
        {
            return new Response<T> { Data = default, StatusCode = statusCode,IsSuccess = true };
        }
        public static Response<T> Failed(int statusCode,ErrorDto errorDto)
        {
            return new Response<T> {StatusCode = statusCode, Error=errorDto, IsSuccess = false};
        }
        public static Response<T> Failed(int statusCode, string error)
        {
            ErrorDto errorDto = new ErrorDto(error, true);
            return new Response<T> { StatusCode = statusCode, Error = errorDto, IsSuccess = false };
        }
    }
}
