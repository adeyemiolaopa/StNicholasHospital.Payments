using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace StNicholasHospital.Payments.Domain.Exceptions
{
    public class InvalidStaffIDOrPasswordException : Exception, ISerializable
    {
        public InvalidStaffIDOrPasswordException() : base()
        {
        }

        public InvalidStaffIDOrPasswordException(string message) : base(message)
        {
        }

        public InvalidStaffIDOrPasswordException(string message, Exception inner) : base(message, inner)
        {
        }

        protected InvalidStaffIDOrPasswordException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
