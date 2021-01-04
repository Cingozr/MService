using MediatR;
using Report.Data.Entities;

namespace Report.Service.Command.Create
{
    public class CreateContactInformationCommand : IRequest<Unit>
    {
        public ContactInformations ContactInformation { get; set; }
    }
}
