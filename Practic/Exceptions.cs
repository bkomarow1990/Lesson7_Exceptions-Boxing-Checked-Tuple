using System;
using System.Collections.Generic;
using System.Text;

namespace Practic
{
    class SalaryException : ApplicationException
    {
        public SalaryException(string message = "SalaryException")
        : base(message) { }
    }
}
