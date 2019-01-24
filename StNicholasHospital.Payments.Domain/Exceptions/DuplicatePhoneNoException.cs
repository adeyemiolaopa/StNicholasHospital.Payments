using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace StNicholasHospital.Payments.Domain.Exceptions
{
    public class DuplicatePhoneNoException : Exception, ISerializable
    {
        public DuplicatePhoneNoException() : base()
        {
        }

        public DuplicatePhoneNoException(string message) : base(message)
        {
        }

        public DuplicatePhoneNoException(string message, Exception inner) : base(message, inner)
        {
        }

        protected DuplicatePhoneNoException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
