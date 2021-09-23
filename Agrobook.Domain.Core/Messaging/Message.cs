namespace Agrobook.Domain.Core.Messaging
{
    using Agrobook.Domain.Core.Attributes;
    using System;

    public abstract class Message 
    {
        [SwaggerExclude]
        public string MessageType { get; protected set; }

        [SwaggerExclude]
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
