using Core.Domain.Entities.Base;

namespace Core.Domain.Entities
{
    public class ContactUsInformation : Entity<Guid>
    {
        public string Description { get; set; } = string.Empty;
        public string AddressText { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string GithubLink { get; set; } = string.Empty;
        public string LinkedInLink { get; set; } = string.Empty;
        public string TwitterLink { get; set; } = string.Empty;
        public string WhatsAppLink { get; set; } = string.Empty;

        public ContactUsInformation()
        {

        }
        public ContactUsInformation(Guid id, string description, string addressText, string email, string phoneNumber, string githubLink, string linkedInLink, string twitterLink, string whatsAppLink)
        {
            Description = description;
            AddressText = addressText;
            Email = email;
            PhoneNumber = phoneNumber;
            GithubLink = githubLink;
            LinkedInLink = linkedInLink;
            TwitterLink = twitterLink;
            WhatsAppLink = whatsAppLink;
        }


    }
}
