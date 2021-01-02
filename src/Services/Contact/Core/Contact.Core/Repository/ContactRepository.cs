using Contact.Data.Contexts;
using Contact.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Contact.Core.Repository
{
    public class ContactRepository : Repository<Contacts>, IContactRepository
    {
        public ContactRepository(ContactContext contactContext) : base(contactContext) { }

        public async Task<bool> AddContact(Contacts model, CancellationToken cancellationToken)
        {
            await _contactContext.Contacts.AddAsync(model, cancellationToken);
            return await _contactContext.SaveChangesAsync(cancellationToken) > 0;
        }

        public async Task<bool> AddContactInformationToPerson(ContactInformations model, CancellationToken cancellationToken)
        {
            await _contactContext.ContactInformations.AddAsync(model, cancellationToken);
            return await _contactContext.SaveChangesAsync(cancellationToken) > 0;
        }


        public async Task<List<Contacts>> GetContactInformation(CancellationToken cancellationToken)
        {
            return await _contactContext.Contacts.Include(x => x.ContactInformations).ToListAsync(cancellationToken: cancellationToken);
        }

        public async Task<List<Contacts>> ListContacts(CancellationToken cancellationToken)
        {
            return await _contactContext.Contacts.ToListAsync(cancellationToken: cancellationToken);
        }

        public async Task<bool> RemoveContact(Contacts model, CancellationToken cancellationToken)
        {
            _contactContext.Contacts.Remove(model);
            return await _contactContext.SaveChangesAsync(cancellationToken) > 0;
        }

        public async Task<bool> RemoveContactInformationToPerson(Guid id, CancellationToken cancellationToken)
        {
            var contactInformation = await _contactContext.ContactInformations.FirstOrDefaultAsync(x => x.ContactId == id, cancellationToken);
            _contactContext.ContactInformations.Remove(contactInformation);
            return await _contactContext.SaveChangesAsync(cancellationToken) > 0;
        }
         
    }
}
