using FluentAssertions;
using ITManager.Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITManager.Tests.Domain.Entities
{
    [TestClass]
    public class UserTest
    {
        [TestMethod]
        public void NewUserOk()
        {
            //Arrange
            var user = new User("Regis", "Zanella", "zanella.regis@gmail.com", "12345", true);
            //Action

            //Assert
            user.Name.Should().Be("Regis");
            user.LastName.Should().Be("Zanella");
            user.Email.Should().Be("zanella.regis@gmail.com");
            user.Password.Should().Be("12345");
            user.Active.Should().Be(true);
        }
    }
}
