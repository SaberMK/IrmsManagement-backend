using AutoMapper;
using IrmsManagement.Api.Commands;
using IrmsManagement.Api.Controllers;
using IrmsManagement.Api.Dtos;
using IrmsManagement.Api.Queries.Contacts;
using IrmsManagement.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace IrmsManagement.UnitTests
{
    public class Tests
    {
        private List<Contact> _contacts = new List<Contact>();
        private Mock<IMediator> _mediator = new Mock<IMediator>();

        private CreateContactCommand _createContactCommand;
        private UpdateContactCommand _updateContactCommand;
        private DeleteContactCommand _deleteContactCommand;

        [SetUp]
        public void Setup()
        {
            _mediator
                .Setup(x => x.Send(It.IsAny<GetAllContactsQuery>(), new CancellationToken()))
                .Returns(Task.FromResult((IEnumerable<GetContactDto>)new List<GetContactDto> { new GetContactDto
                {
                    Id = 1,
                    Email = "Email",
                    FullName = "Full name",
                    MobileNumber = "88005553555",
                    PreferredName = "Preffered name",
                    Title = "Title"
                } }));

            _mediator
                .Setup(x => x.Send(It.IsAny<GetContactByIdQuery>(), new CancellationToken()))
                .Returns(Task.FromResult( new GetContactDto
                {
                    Id = 1,
                    Email = "Email",
                    FullName = "Full name",
                    MobileNumber = "88005553555",
                    PreferredName = "Preffered name",
                    Title = "Title"
                }));

            _mediator
                .Setup(x => x.Send(It.IsAny<CreateContactCommand>(), new CancellationToken()))
                .Returns(Task.FromResult(new GetContactDto
                {
                    Id = 1,
                    Email = "Email",
                    FullName = "Full name",
                    MobileNumber = "88005553555",
                    PreferredName = "Preffered name",
                    Title = "Title"
                }));

            _mediator
               .Setup(x => x.Send(It.IsAny<UpdateContactCommand>(), new CancellationToken()))
               .Returns(Task.FromResult(new GetContactDto
               {
                   Id = 1,
                   Email = "Email",
                   FullName = "Full name",
                   MobileNumber = "88005553555",
                   PreferredName = "Preffered name",
                   Title = "Title"
               }));

            _mediator
               .Setup(x => x.Send(It.IsAny<DeleteContactCommand>(), new CancellationToken()))
               .Returns(Task.FromResult(true));
        }
        
        [Test]
        public async Task Contact_Add()
        {
            var contact = new AddContactDto
            {
                Email = "Email",
                FullName = "Full name",
                MobileNumber = "88005553555",
                PreferredName = "Preffered name",
                Title = "Title"
            };
            var controller = new ContactController(_mediator.Object, Mock.Of<IMapper>());

            var result = await controller.Add(contact);
                        
            Assert.IsInstanceOf<OkObjectResult>(result);
         
            Assert.Pass();
        }


        [Test]
        public async Task Contact_Update()
        {
            var contact = new UpdateContactDto
            {
                Id = 2,
                Email = "Email",
                FullName = "Full name",
                MobileNumber = "88005553555",
                PreferredName = "Preffered name",
                Title = "Title"
            };

            var controller = new ContactController(_mediator.Object, Mock.Of<IMapper>());

            var result = await controller.Update(contact);

            Assert.IsInstanceOf<OkObjectResult>(result);

            Assert.Pass();
        }


        [Test]
        public async Task Contact_Delete()
        {
            var id = 1;

            var controller = new ContactController(_mediator.Object, Mock.Of<IMapper>());

            var result = await controller.Delete(id);

            Assert.IsInstanceOf<OkObjectResult>(result);

            Assert.Pass();
        }


        [Test]
        public async Task Contact_GetById()
        {
            var id = 1;

            var controller = new ContactController(_mediator.Object, Mock.Of<IMapper>());

            var result = await controller.GetById(id);

            Assert.IsInstanceOf<OkObjectResult>(result);

            Assert.Pass();
        }


        [Test]
        public async Task Contact_GetAll()
        {
            var controller = new ContactController(_mediator.Object, Mock.Of<IMapper>());

            var result = await controller.GetAll();

            Assert.IsInstanceOf<OkObjectResult>(result);

            Assert.Pass();
        }
    }
}