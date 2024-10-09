using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.Domain.Exceptions
{
    public class AlreadyExistsRecordException : Exception
    {
        public AlreadyExistsRecordException()
        {

        }

        public AlreadyExistsRecordException(string message) : base(message)
        {

        }
    }
}
