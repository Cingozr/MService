using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Report.Service.Query.List
{
    public class GetAllNumbersInLocationQuery : IRequest<int>
    {
        public string Location { get; set; }
    }
}
