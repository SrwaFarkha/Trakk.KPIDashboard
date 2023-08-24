using System;


namespace Trakk.WebApi.DatabaseModels.Models
{
    public class ErrorLog : IEntity
    {
        public int ErrorLogId { get; set; } // ErrorLogId (Primary key)
        public string Http { get; set; } // Http
        public string Message { get; set; } // Message
        public string StackTrace { get; set; } // StackTrace
        public DateTime Created { get; set; } // Created

        public ErrorLog()
        {
            Created = DateTime.UtcNow;
        }
    }
}