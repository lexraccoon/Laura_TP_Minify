using System;
using Minify.Controllers;
using Minify.Interfaces;
using MongoDB.Driver;
using Xunit;
using Moq;

namespace Minify.Tests
{
    public class MongoRepositoryTest
    {
        private Mock<IMongoDatabase> database;
        
        public MongoRepositoryTest()
        {
            database = new Mock<IMongoDatabase>();

        }
    }
}