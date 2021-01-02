using Contact.Data.Entities;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Contact.Core.Repository
{
    public interface IContactRepository
    {
        Task<bool> AddContact(Contacts model, CancellationToken cancellationToken); //Rehberde kişi oluşturma      
        Task<bool> RemoveContact(Contacts model, CancellationToken cancellationToken);   //Rehberde kişi kaldırma
        Task<bool> AddContactInformationToPerson(ContactInformations model, CancellationToken cancellationToken); //Rehberdeki kişiye iletişim bilgisi ekleme
        Task<bool> RemoveContactInformationToPerson(Guid id, CancellationToken cancellationToken); //Rehberdeki kişiden iletişim bilgisi kaldırma
        Task<List<Contacts>> ListContacts(CancellationToken cancellationToken); //Rehberdeki kişilerin listelenmesi
        Task<List<Contacts>> GetContactInformation(CancellationToken cancellationToken); //Rehberdeki bir kişiyle ilgili iletişim bilgilerinin de yer aldığı detay bilgilerin getirilmesi

    }
}
