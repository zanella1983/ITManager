using FluentAssertions;
using ITManager.Domain.Entities;
using ITManager.Repositories;
using ITManager.Repositories.lib;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITManager.Tests.Repositories
{
    [TestClass]
    public class UserRepositoryTest
    {
        private List<User> _users;

        [TestInitialize]
        public void Initialize()
        {
            _users = new List<User>();
            _users.Add(new User("Regis", "Zanella", "zanella.regis@gmail.com", "12345", true));
            _users.Add(new User("João", "Silva", "joao@gmail.com", "23456", true));
            _users.Add(new User("Maria", "Santos", "maria@gmail.com", "34567", true));
            _users.Add(new User("Jose", "Costa", "jose@gmail.com", "45678", true));
        }

        [TestMethod]
        public void GetByEmailAndPasswordOk()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<ITManagerDbContext>().UseInMemoryDatabase(databaseName: "TestDb").Options;
            var dbContext = new ITManagerDbContext(options);
            dbContext.Database.EnsureDeleted();
            dbContext.Users.AddRange(_users);
            dbContext.SaveChanges();

            var repository = new UserRepository(dbContext);
            //Action
            var result = repository.GetByEmailAndPassword("zanella.regis@gmail.com", "12345");

            //Assert
            result.Should().NotBeNull();
            result.Email.Should().Be("zanella.regis@gmail.com");
            result.Password.Should().Be("12345");
            result.Name.Should().Be("Regis");
            result.LastName.Should().Be("Zanella");
        }

        [TestMethod]
        public void GetByEmailAndPasswordNOk()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<ITManagerDbContext>().UseInMemoryDatabase(databaseName: "TestDb").Options;
            var dbContext = new ITManagerDbContext(options);
            dbContext.Database.EnsureDeleted();
            dbContext.Users.AddRange(_users);
            dbContext.SaveChanges();

            var repository = new UserRepository(dbContext);
            //Action
            var result = repository.GetByEmailAndPassword("zanella.regis@gmail.com", "1245");

            //Assert
            result.Should().BeNull();
            
        }
    }
}
