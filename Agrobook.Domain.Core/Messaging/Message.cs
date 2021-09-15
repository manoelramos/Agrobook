namespace Agrobook.Domain.Core.Messaging
{
    using System;

    public abstract class Message 
    {
        
        public string MessageType { get; protected set; }

        public Guid AggregateId { get; protected set; }

        //public User User { get; private set; }

        //User IUserAccessor.User
        //{
        //    get => User;
        //    set => User = value;
        //}

        protected Message()
        {
            MessageType = GetType().Name;
        }
    }
}
