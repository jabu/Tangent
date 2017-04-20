using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIServices.Exceptions
{
    [Serializable]
    public class UnsuccessfulQueryException : Exception
    {
        public UnsuccessfulQueryException()
            : base()
        { }

        public UnsuccessfulQueryException(string errorMessage)
            : base(errorMessage)
        { }
    }
}
