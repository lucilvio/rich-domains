using System;
using System.Runtime.Serialization;

namespace Lucilvio.TicketMe.AnemicModel.Tickets
{
    [Serializable]
    internal class CantDisableUnavailableTickets : Exception
    {
        public CantDisableUnavailableTickets()
        {
        }

        public CantDisableUnavailableTickets(string message) : base(message)
        {
        }

        public CantDisableUnavailableTickets(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected CantDisableUnavailableTickets(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}