using DesafioAutoGlass.Domain.Core.Notifications;

namespace DesafioAutoGlass.Domain.Core.Interfaces.Services
{
    public interface INotifier
    {
        bool HasNotification();

        List<Notification> GetNotifications();

        void Handle(Notification notification);

        void AddNotification(string message);
    }
}