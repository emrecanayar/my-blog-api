using Core.Domain.Entities.Base;

namespace Core.Domain.Entities
{
    public class Subscription : Entity<Guid>
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public Guid? UserId { get; set; }
        public User User { get; set; }
        public ICollection<Notification> Notifications { get; set; }

        public Subscription()
        {
            User = default!;
            Notifications = [];
        }

        public Subscription(Guid id, string firstName, string lastName, string email, Guid? userId)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            UserId = userId;
            User = default!;
            Notifications = [];
        }
    }
}
