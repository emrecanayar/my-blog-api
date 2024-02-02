using Core.Domain.Entities.Base;

namespace Core.Domain.Entities
{
    public class Contact : Entity<Guid>
    {
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;

        public Contact()
        {

        }

        public Contact(Guid id, string fullName, string email, string phoneNumber, string message)
        {
            Id = id;
            FullName = fullName;
            Email = email;
            PhoneNumber = phoneNumber;
            Message = message;
        }
    }
}
