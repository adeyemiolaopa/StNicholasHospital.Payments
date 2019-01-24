using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace StNicholasHospital.Payments.Domain.Exceptions
{
    public class InvalidPatientIDException : Exception, ISerializable
    {
        public InvalidPatientIDException() : base()
        {
        }

        public InvalidPatientIDException(string message) : base(message)
        {
        }

        public InvalidPatientIDException(string message, Exception inner) : base(message, inner)
        {
        }

        protected InvalidPatientIDException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
