using System.Net;

namespace ReceiptApp.API.Security.Exceptions;

public class AppException : Exception
{
    private HttpStatusCode _httpStatusCode;

    public AppException(string? message) : base(message)
    {
       
    }
    public AppException(string? message, HttpStatusCode statusCodes) : base(message)
    {
        _httpStatusCode = statusCodes;
    }
}