using System;
using System.Collections.Generic;
using System.Text;

namespace CustomExceptions.Exceptions
{
    public class GradeException : Exception
    {
        public GradeException(string message)
            : base(message)
        {

        }
        public GradeException()
        {

        }
    }
}
