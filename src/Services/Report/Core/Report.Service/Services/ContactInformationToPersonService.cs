using MediatR;
using Report.Data.Entities;
using Report.Service.Command.Create;
using System;
using System.Diagnostics;

namespace Report.Service.Services
{
    public class ContactInformationToPersonService : IContactInformationToPersonService
    {
        private readonly IMediator _mediator;

        public ContactInformationToPersonService(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async void AddContactInformationToPerson(ContactInformations model)
        {
            try
            {
                await _mediator.Send(new CreateContactInformationCommand
                {
                    ContactInformation = model
                });
            }
            catch (Exception ex)
            {
                // log an error message here
                Debug.WriteLine(ex.Message);
            }
        }
    }
}
