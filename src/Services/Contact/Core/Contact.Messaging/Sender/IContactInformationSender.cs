using Contact.Data.Entities;

namespace Contact.Messaging.Sender
{
    public interface IContactInformationSender
    {
        void AddContactInformationToPerson(ContactInformations model);
    }
}
