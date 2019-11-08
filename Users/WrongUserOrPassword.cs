using System;
using System.Runtime.Serialization;

namespace Lucilvio.TicketMe.AnemicModel.Users
{
    [Serializable]
    internal class WrongUserOrPassword : Exception
    {
        public WrongUserOrPassword()
        {
        }

        public WrongUserOrPassword(string message) : base(message)
        {
        }

        public WrongUserOrPassword(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected WrongUserOrPassword(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}