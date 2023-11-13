using JoTaskMaster.Application.Exceptions.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoTaskMaster.Application.Exceptions.ValidationExceptions
{
    public class ValidationsException : WorkException
    {
        public ValidationsException(IReadOnlyDictionary<string, string[]> errorsDictionary)
           : base("Validation Failure")
           => ErrorsDictionary = errorsDictionary;


        public IReadOnlyDictionary<string, string[]> ErrorsDictionary { get; }
    }
}
