using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Molim.Backend.API.Exceptions
{
    public class ManagedException : Exception
    {
        public string Code { get; private set; }
        public string Description { get; private set; }

        public ManagedException(ExceptionCodes code) : base()
        {
            Code = code.ToString();            
        }

        public ManagedException(ExceptionCodes code, string description) : base()
        {
            Code = code.ToString();
            Description = description;
        }

        public enum ExceptionCodes
        {
            Unknown,
            Generic,
            AuthFail
        }
    }
}
