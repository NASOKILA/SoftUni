using FindMyPet.Data;
using FindMyPet.Models;
using FindMyPet.Tests.Mocks;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FindMyPet.Tests.Controllers.Messages
{
    [TestClass]
    public class MessagesTests
    {
        private FindMyPetDbContext DbContext { get; set; }

        [TestInitialize]
        public void BeforeEachTest()
        {
            this.DbContext = MockDbContext.GetContext();
        }

        [TestCleanup]
        public void AfterEachTest()
        { }

        [TestMethod]
        public void MessagesCount_ShouldReturnAPetMessageCount()
        {
            //Arrange
            var pets = this.DbContext.Pets.Include(p => p.Comments).ToList();
            var petOne = pets[0];

            //Act - do something
            var messages = petOne.Comments.Count;
            var messages2 = petOne.Comments.Count;

            //Assert - check solution
            Assert.AreEqual(messages, messages2);
        }

        [TestMethod]
        public void AddMessage_ShouldReturnOneMoreMessage()
        {
            //Arrange
            var pets = this.DbContext.Users.Include(p => p.MessagesReceived).ToList();
            var petOne = pets[0];

            var messages = petOne.MessagesReceived;
            var messagesCount = petOne.MessagesReceived.Count();


            //Act - do something
            messages.Add(new Models.Message()
            {
                Content = "New Comment",
                CreationDate = DateTime.Now,
                Likes = new List<Like>(),
                LikeDisabled = false
            });

            var messageNewCount = petOne.MessagesReceived.Count();


            //Assert - check solution
            Assert.AreEqual(messagesCount, messageNewCount - 1);
        }

        [TestMethod]
        public void RemoveMessage_ShouldReturnOneLessMessage()
        {
            //Arrange
            var users = this.DbContext.Users.Include(p => p.MessagesReceived).ToList();
            var userTwo = users[1];

            var messages = userTwo.MessagesReceived;
            var messagesCount = userTwo.MessagesReceived.Count();


            //Act - do something
            messages.Remove(messages.Last());

            var messagesNewCount = userTwo.MessagesReceived.Count();


            //Assert - check solution
            Assert.AreEqual(messagesCount, messagesNewCount + 1);
        }

    }
}
