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
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IrmsManagement.UnitTests.Handlers
{
    public class GetAllContactHandlerTest
    {
        private Mock<IContactRepository> _contactRepository = new Mock<IContactRepository>();
        private Mock<IMapper> _mapper = new Mock<IMapper>();

        private IEnumerable<GetContactDto> _getContactDto;

        [Test]
        public async Task GetAllContactHandler_Handle()
        {
            var getAllContactsQuery = new GetAllContactsQuery();
            var data = new List<GetContactDto>
            {
                new GetContactDto
                {
                    Id = 1,
                    Email = "Email",
                    FullName = "Full name",
                    MobileNumber = "88005553555",
                    PreferredName = "Preffered name",
                    Title = "Title"
                },
                new GetContactDto
                {
                    Id = 2,
                    Email = "Email",
                    FullName = "Full name",
                    MobileNumber = "88005553555",
                    PreferredName = "Preffered name",
                    Title = "Title"
                }
            };

            _mapper
                .Setup(x => x.Map<IEnumerable<GetContactDto>>(It.IsAny<IEnumerable<Contact>>()))
                .Returns(new List<GetContactDto>{new GetContactDto
                {
                    Id = 1,
                    Email = data[0].Email,
                    FullName = data[0].FullName,
                    MobileNumber = data[0].MobileNumber,
                    PreferredName = data[0].PreferredName,
                    Title = data[0].Title,
                } });

            _contactRepository
                .Setup(x => x.GetContactsAsync())
                .Returns(Task.FromResult((IEnumerable<Contact>)new List<Contact> {
                new Contact{
                    Id = 1,
                    Email = "Email",
                    FullName = "Full name",
                    MobileNumber = "88005553555",
                    PreferredName = "Preffered name",
                    Title = "Title"
                }}));

            var commandHandler = new GetAllContactsHandler(_contactRepository.Object, _mapper.Object);
            _getContactDto = await commandHandler.Handle(getAllContactsQuery, new CancellationToken());

            var first = _getContactDto.First();

            Assert.IsNotNull(first);
            Assert.Greater(first.Id, 0);
        }
    }
}
