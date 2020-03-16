using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IrmsManagement.Api.Commands
{
    public class DeleteContactCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
