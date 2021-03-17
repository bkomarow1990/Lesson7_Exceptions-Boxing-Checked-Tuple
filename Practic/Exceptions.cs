using System;
using System.Collections.Generic;
using System.Text;

namespace Exceptions
{
    class SalaryException : ApplicationException
    {
        public SalaryException(string message = "SalaryException")
        : base(message) { }
    }
    class EmployeeException : ApplicationException
    {
        public EmployeeException(string message = "EmployeeException")
        : base(message) { }
    }
}
