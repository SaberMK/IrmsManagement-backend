using AutoMapper;
using IrmsManagement.Api.Commands;
using IrmsManagement.Api.Dtos;
using IrmsManagement.Models;

namespace IrmsManagement.Api.Mappings
{
    public class ContractMapping : Profile
    {
        public ContractMapping()
        {
            CreateMap<Contact, GetContactDto>();

            CreateMap<AddContactDto, CreateContactCommand>();

            CreateMap<UpdateContactDto, UpdateContactCommand>();
        }
    }
}