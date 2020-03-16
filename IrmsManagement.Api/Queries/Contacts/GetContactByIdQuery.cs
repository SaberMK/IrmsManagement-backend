using IrmsManagement.Api.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IrmsManagement.Api.Queries.Contacts
{
    public class GetContactByIdQuery : IRequest<GetContactDto>
    {
        public int Id { get; }
        public GetContactByIdQuery(int id)
        {
            Id = id;
        }
    }
}
