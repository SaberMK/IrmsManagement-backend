using AutoMapper;
using IrmsManagement.Api.Dtos;
using IrmsManagement.Api.Handlers;
using IrmsManagement.Api.Queries.Contacts;
using IrmsManagement.Data.Repositories.Interfaces;
using IrmsManagement.Models;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IrmsManagement.UnitTests.Handlers
{
    public class GetContactByIdTest
    {
        private Mock<IContactRepository> _contactRepository = new Mock<IContactRepository>();
        private Mock<IMapper> _mapper = new Mock<IMapper>();

        private GetContactDto _getContactDto;
        
        [Test]
        public async Task GetContacyById_Handle()
        {
            var getContactByIdQuery = new GetContactByIdQuery(It.IsAny<int>());

            _contactRepository
                .Setup(x => x.GetById(It.IsAny<int>()))
                .Returns(Task.FromResult(
                new Contact{
                    Id = 1,
                    Email = "Email",
                    FullName = "Full name",
                    MobileNumber = "88005553555",
                    PreferredName = "Preffered name",
                    Title = "Title"
                }));

            _mapper
                .Setup(x => x.Map<GetContactDto>(It.IsAny<Contact>()))
                .Returns(new GetContactDto
                {
                    Id = 1,
                    Email = "Email",
                    FullName = "Full name",
                    MobileNumber = "88005553555",
                    PreferredName = "Preffered name",
                    Title = "Title"
                } );

            var commandHandler = new GetContactByIdHandler(_contactRepository.Object, _mapper.Object);
            _getContactDto = await commandHandler.Handle(getContactByIdQuery, new CancellationToken());

            Assert.IsNotNull(_getContactDto);
            Assert.Greater(_getContactDto.Id, 0);
        }
    }
}
