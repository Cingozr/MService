using Contact.Core.Repository;
using Contact.Data.Contexts;
using Contact.Data.Entities;
using Contact.Data.Test.Infrastructure;
using FakeItEasy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.Data.Test.Repository
{
    public class RepositoryTests : DatabaseTestBase
    {
        private readonly ContactContext _contactContext;
        private readonly Repository<Contacts> _test;
        private readonly Repository<Contacts> _testFake;
        private readonly Contacts _newCustomer;

        public RepositoryTests()
        {
            _contactContext = A.Fake<ContactContext>();
            _testFake = new Repository<Contacts>(_contactContext);
            _test = new Repository<Contacts>(Context);
            _newCustomer = new Contacts
            {
                Name = "Recai",
                Surname = "Cingoz",
                Company = "Cingoz LTD",
            };
        }
    }
}
