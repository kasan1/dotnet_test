using System.Collections.Generic;

namespace Agro.Shared.Logic.Models.Common
{
    public static class Response
    {
        public static Response<T> Success<T>(string message, T data = default) => new Response<T>(message, data);
        public static Response<T> Fail<T>(string message, IDictionary<string, string[]> errors = default) => 
            new Response<T>(message, errors: errors ?? new Dictionary<string, string[]>());
    }

    public class Response<T>
    {
        public Response(string message, T data = default, IDictionary<string, string[]> errors = default)
        {
            Message = message;
            Data = data;
            Errors = errors;
        }

        public T Data { get; set; }
        public string Message { get; set; }
        public IDictionary<string, string[]> Errors { get; set; }
        public bool Succeed => Errors == null;
    }
}
