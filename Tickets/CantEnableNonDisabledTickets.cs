using System;
using System.Runtime.Serialization;

namespace Lucilvio.TicketMe.AnemicModel.Tickets
{
    [Serializable]
    internal class CantEnableNonDisabledTickets : Exception
    {
        public CantEnableNonDisabledTickets()
        {
        }

        public CantEnableNonDisabledTickets(string message) : base(message)
        {
        }

        public CantEnableNonDisabledTickets(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected CantEnableNonDisabledTickets(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}