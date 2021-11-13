using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentValidation.Results;

namespace Travel.Application.Common.Exceptions
{
    public  class ValidationException : Exception
    {
        public ValidationException() : base("One or more validation failures have occured.")
        {
            Errors = new Dictionary<string, string[]>();
        }
        
        public ValidationException(IEnumerable<ValidationFailure> failures) : this()
        {
            var failureGroups = failures.GroupBy(e => e.PropertyName, e => e.ErrorMessage);
            foreach (var item in failureGroups)
            {

            }
        }
        public IDictionary<string,string[]> Errors { get; }
    }
}
