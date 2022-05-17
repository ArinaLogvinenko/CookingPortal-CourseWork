namespace CookingPortal.Middleware
{
    using System;
    using System.Net;

    public class AppException : Exception
    {
        public AppException(int statusCode, string message, string detail = "")
            : base(message)
        {
            StatusCode = statusCode;
            Detail = detail;
        }

        public int StatusCode { get; set; }

        public string Detail { get; set; }
    }
}
