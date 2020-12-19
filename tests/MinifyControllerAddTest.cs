using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using Bogus;
using Minify.Controllers;
using Minify.Interfaces;
using Minify.Model;
using Moq;
using Xunit;

namespace Minify.Tests
{
    public class MinifyControllerAddTest
    {
        private readonly Mock<IRepository> _repo;
        private readonly Mock<ITokenGenerator> _tokenGenerator;
        private readonly MinifyController _minifyController;
        private readonly string _token = Guid.NewGuid().ToString();

        public MinifyControllerAddTest()
        {
            _repo = new Mock<IRepository>();
            _tokenGenerator = new Mock<ITokenGenerator>();
            _minifyController = new MinifyController(_repo.Object, _tokenGenerator.Object);

            _tokenGenerator.Setup(a => a.Generate()).Returns(_token);
            _repo.Setup(a => a.Add(It.IsAny<MinifyData>()));
        }

        [Fact]
        public void AddMinifyController()
        {
            MinifyData minifyData = new MinifyData
            {
                Url = new Faker().Internet.Url()
            };

            var result = _minifyController.Add(minifyData);
            
            _repo
                .Verify(a => 
                    a.Add(It.Is<MinifyData>(data => data.Url == minifyData.Url
                    && data.Key == _token)));
        }
        
    }
}