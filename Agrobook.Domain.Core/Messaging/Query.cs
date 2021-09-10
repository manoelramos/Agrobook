namespace Agrobook.Domain.Core.Messaging
{
    using Flunt.Notifications;
    using MediatR;

    public abstract class Query<TResponse> : Notifiable<Notification>, IRequest<TResponse>
    {

    }
}
