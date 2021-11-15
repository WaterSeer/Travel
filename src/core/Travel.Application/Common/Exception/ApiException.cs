using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Travel.Application.Common.Exceptions
{
    public class ApiException
    {
        public ApiException() : base() { }

        public ApiException(string message) : base(message) { }

        public ApiException(string message, params object[] args) : base(String.Format(CultureInfo.CurrentCulture, message, args)) { }
    }
}
