using System;
using System.Runtime.Serialization;

namespace Lucilvio.TicketMe.AnemicModel.Tickets
{
    [Serializable]
    internal class CantEditTicketsThereWereBoughtOrUsed : Exception
    {
        public CantEditTicketsThereWereBoughtOrUsed()
        {
        }

        public CantEditTicketsThereWereBoughtOrUsed(string message) : base(message)
        {
        }

        public CantEditTicketsThereWereBoughtOrUsed(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected CantEditTicketsThereWereBoughtOrUsed(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}