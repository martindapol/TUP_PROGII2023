using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ProduccionFront.Http
{
    public class ResponseHttp
    {
        public HttpStatusCode StatusCode { get; set; }
        public string Data { get; set; }

        public ResponseHttp(HttpStatusCode code, string data)
        {
            StatusCode = code;
            Data = data;
        }
    }
}
