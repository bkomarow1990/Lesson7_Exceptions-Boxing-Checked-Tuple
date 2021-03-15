using System;
using System.Collections.Generic;
using System.Text;

namespace Exceptions
{
    class NameException : ApplicationException
    {
        public NameException(string message = "NameException")
        : base(message) { }
    }
    class SurnameException : ApplicationException
    {
        public SurnameException(string message = "SurnameException")
        : base(message) { }
    }
}
