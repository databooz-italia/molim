using System;
using System.Collections.Generic;
using System.Text;

namespace Molim.Backend.API.BusinessLayer.Exceptions
{
    public class BusinessManagedException : Exception
    {
        public string Code { get; private set; }
        public string Description { get; private set; }

        public BusinessManagedException(string code) : base()
        {
            Code = code;            
        }

        public BusinessManagedException(string code, string description) : base()
        {
            Code = code;
            Description = description;
        }
    }
}
