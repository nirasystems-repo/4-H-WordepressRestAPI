using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using _4HWordPress.Core.Common;

namespace _4HWordPress.Core.Domain
{
    /// <summary>
    /// 
    /// </summary>
    public class APIResponse
    {
        /// <summary>
        /// Gets or sets the data.
        /// </summary>
        /// <value>
        /// The data.
        /// </value>
        public ResponseData Data { get; set; }

        /// <summary>
        /// Gets or sets the code.
        /// </summary>
        public HttpStatusCode Code { get; set; }


        /// <summary>
        /// Initializes a new instance of the <see cref="Domain.JsonResult" /> class.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="code">The code.</param>
        public APIResponse(object value, HttpStatusCode code)
        {
            Data = new ResponseData { Value = value, Message = "Success" };
            Code = code;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="APIResponse"/> class.
        /// </summary>
        /// <param name="code">The code.</param>
        public APIResponse(HttpStatusCode code, string message)
        {
            Code = code;
            Data = new ResponseData { Message = message };
        }

        public APIResponse(HttpStatusCode code)
        {
            Code = code;
            Data = new ResponseData { Message = "Success" };
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class ResponseData
    {
        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        public object Value { get; set; }

        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        /// <value>
        /// The message.
        /// </value>
        public string Message { get; set; }
    }
}
