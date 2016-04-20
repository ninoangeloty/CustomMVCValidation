using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessCore
{
    public class BusinessValidationResult
    {
        public BusinessValidationResult(string message, string property)
        {
            Message = message;
            Property = property;
        }

        public string Property { get; set; }
        public string Message { get; set; }
    }
}
