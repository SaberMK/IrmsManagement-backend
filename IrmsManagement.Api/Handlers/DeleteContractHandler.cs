using AutoMapper;
using IrmsManagement.Api.Commands;
using IrmsManagement.Data.Repositories.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace IrmsManagement.Api.Handlers
{
    public class DeleteContractHandler : IRequestHandler<DeleteContactCommand, bool>
    {
        private readonly IContactRepository _contactRepository;
        private readonly IMapper _mapper;

        public DeleteContractHandler(IContactRepository contactRepository,
            IMapper mapper)
        {
            _contactRepository = contactRepository;
            _mapper = mapper;
        }
        public async Task<bool> Handle(DeleteContactCommand request, CancellationToken cancellationToken)
        {
            var contact = await _contactRepository.GetById(request.Id);

            if (contact == null)
                return false;

            await _contactRepository.Delete(request.Id);
            await _contactRepository.SaveAsync();

            return true;
        }
    }
}
