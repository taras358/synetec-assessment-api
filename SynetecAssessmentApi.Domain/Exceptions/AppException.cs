using System;
using System.Collections.Generic;
using System.Net;

namespace SynetecAssessmentApi.Domain.Exceptions
{
    public class AppException: Exception
    {
        public HttpStatusCode StatusCode { get; set; }
        public IEnumerable<string> Descriptions { get; set; }

        public AppException(string description, 
            HttpStatusCode errorCode = HttpStatusCode.InternalServerError)
        {
            StatusCode = errorCode;
            Descriptions = new List<string>() { description };
        }

        public AppException(IEnumerable<string> descriptions, 
            HttpStatusCode errorCode = HttpStatusCode.InternalServerError)
        {
            StatusCode = errorCode;
            Descriptions = descriptions;
        }
    }
}