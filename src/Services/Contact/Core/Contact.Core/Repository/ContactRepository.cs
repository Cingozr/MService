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
            if (model == null)
                throw new ArgumentNullException($"{nameof(AddAsync)} entity must not be null");

            try
            {
                await _contactContext.Contacts.AddAsync(model, cancellationToken);
                return await _contactContext.SaveChangesAsync(cancellationToken) > 0;
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(model)} could not be saved: {ex.Message}");
            }

        }

        public async Task<bool> AddContactInformationToPerson(ContactInformations model, CancellationToken cancellationToken)
        {
            if (model == null)
                throw new ArgumentNullException($"{nameof(AddAsync)} entity must not be null");

            try
            {
                await _contactContext.ContactInformations.AddAsync(model, cancellationToken);
                return await _contactContext.SaveChangesAsync(cancellationToken) > 0;
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(model)} could not be saved: {ex.Message}");
            }

        }

        public async Task<List<Contacts>> GetAllContactInformation(CancellationToken cancellationToken)
        {
            try
            {
                return await _contactContext.Contacts.Include(x => x.ContactInformations).ToListAsync(cancellationToken: cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(GetAllContactInformation)} {ex.Message}");
            }

        }

        public async Task<List<Contacts>> GetAllContact(CancellationToken cancellationToken)
        {
            try
            {
                return await _contactContext.Contacts.ToListAsync(cancellationToken: cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(GetAllContact)} { ex.Message}");
            }

        }

        public async Task<bool> RemoveContact(Guid contactId, CancellationToken cancellationToken)
        {
            if (contactId == Guid.Empty)
                throw new ArgumentNullException($"{nameof(RemoveContact)} contactId must not be null");

            try
            {
                _contactContext.Contacts.Remove(await _contactContext.Contacts.FirstOrDefaultAsync(x => x.UUID == contactId, cancellationToken));
                return await _contactContext.SaveChangesAsync(cancellationToken) > 0;
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(RemoveContact)} : {ex.Message}");
            }

        }

        public async Task<bool> RemoveContactInformationToPerson(Guid contactId, CancellationToken cancellationToken)
        {
            if (contactId == Guid.Empty)
                throw new ArgumentNullException($"{nameof(RemoveContactInformationToPerson)} contactId must not be null");

            try
            {
                _contactContext.ContactInformations.Remove(await _contactContext.ContactInformations.FirstOrDefaultAsync(x => x.ContactId == contactId, cancellationToken));
                return await _contactContext.SaveChangesAsync(cancellationToken) > 0;
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(RemoveContactInformationToPerson)} : {ex.Message}");
            }

        }

    }
}
