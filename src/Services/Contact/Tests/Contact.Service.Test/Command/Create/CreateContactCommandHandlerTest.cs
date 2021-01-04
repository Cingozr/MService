using Contact.Core.Repository;
using Contact.Data.Entities;
using Contact.Service.Command.Create;
using FakeItEasy;
using Xunit;

namespace Contact.Service.Test.Command.Create
{
    public class CreateContactCommandHandlerTest
    {
        private readonly CreateContactCommandHandler _test;
        private readonly IContactRepository _contactRepository;

        public CreateContactCommandHandlerTest()
        {
            _contactRepository = A.Fake<IContactRepository>();
            _test = new CreateContactCommandHandler(_contactRepository);
        }


        [Fact]
        public async void Handle_ShouldCallAddAsync()
        {
            await _test.Handle(new CreateContactCommand(), default);

            A.CallTo(() => _contactRepository.AddAsync(A<Contacts>._)).MustHaveHappenedOnceExactly();
        }
    }
}
