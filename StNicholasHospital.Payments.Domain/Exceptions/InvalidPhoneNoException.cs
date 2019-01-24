using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace StNicholasHospital.Payments.Domain.Exceptions
{
    public class InvalidPhoneNoException : Exception, ISerializable
    {
        public InvalidPhoneNoException() : base()
        {
        }

        public InvalidPhoneNoException(string message) : base(message)
        {
        }

        public InvalidPhoneNoException(string message, Exception inner) : base(message, inner)
        {
        }

        protected InvalidPhoneNoException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
