using System;
using System.Collections.Generic;
using System.Text;

namespace Exceptions
{
    class LoginExcpetion : ApplicationException
    {
        public LoginExcpetion(string message = "LoginException")
        : base(message) { }
    }
}
