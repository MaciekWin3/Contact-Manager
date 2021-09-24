using System.Net;

namespace Core.Responses
{
    public abstract class BaseResponse
    {
        public HttpStatusCode StatusCode { get; protected set; }
        public string Message { get; protected set; }
        protected BaseResponse(HttpStatusCode statusCode, string message)
        {
            StatusCode = statusCode;
            Message = message;
        }
    }
}
