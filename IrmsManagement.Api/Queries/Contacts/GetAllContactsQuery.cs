using IrmsManagement.Api.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IrmsManagement.Api.Queries.Contacts
{
    public class GetAllContactsQuery : IRequest<IEnumerable<GetContactDto>>
    {
        
    }
}
