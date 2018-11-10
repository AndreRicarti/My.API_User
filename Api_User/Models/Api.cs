using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_User.Models
{
    public class Error
    {
        public string Code { get; set; }
        public string Message { get; set; }
    }

    public class ApiError
    {
        public Error Error { get; set; }
    }
}
