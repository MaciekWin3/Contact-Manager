using Core;
using Core.Data.Repositories;
using Core.Models;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Tests
{
    internal class ContactsUnitTests
    {
        private Contact contact;
        private List<Contact> contacts;
        private Mock<IContactRepository> contactsRepositoryMock;
        private Mock<ApplicationDbContext> applicationDbContextMock;

        [SetUp]
        public void Setup()
        {
            contact = new Contact
            {
                Id = 1
            };

            List<Contact> contactsCollection = new List<Contact>();
            for (var i = 0; i < 3; i++)
            {
                contactsCollection.Add(new Contact { Id = 1 + i });
            }

            contacts = contactsCollection;
            contactsRepositoryMock = new Mock<IContactRepository>();
        }

        [Test]
        public async Task GetContactsAsync()
        {
            contactsRepositoryMock
                .Setup(c => c.GetAllAsync())
                .Returns(Task.FromResult(contacts));

            var contactRepository = new ContactRepository(applicationDbContextMock.Object);
            var result = await contactRepository.GetAllAsync();

            Assert.AreEqual(result.Count, contacts.Count);

        }
    }
}
