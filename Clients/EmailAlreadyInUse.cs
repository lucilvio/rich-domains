using System;
using System.Runtime.Serialization;

namespace Lucilvio.TicketMe.AnemicModel.Clients
{
    [Serializable]
    internal class EmailAlreadyInUse : Exception
    {
        public EmailAlreadyInUse()
        {
        }

        public EmailAlreadyInUse(string message) : base(message)
        {
        }

        public EmailAlreadyInUse(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected EmailAlreadyInUse(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}