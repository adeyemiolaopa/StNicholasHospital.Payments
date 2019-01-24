using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace StNicholasHospital.Payments.Domain.Exceptions
{
    public class InvalidPaymentIDException: Exception, ISerializable
    {
        public InvalidPaymentIDException() : base()
        {
        }

        public InvalidPaymentIDException(string message) : base(message)
        {
        }

        public InvalidPaymentIDException(string message, Exception inner) : base(message, inner)
        {
        }

        protected InvalidPaymentIDException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
