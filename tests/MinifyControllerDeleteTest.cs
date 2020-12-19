using System;
using Minify.Controllers;
using Minify.Interfaces;
using Xunit;
using Moq;

namespace Minify.Tests
{
    public class MinifyControllerDeleteTest
    {
        private readonly Mock<IRepository> _repo;
        private readonly Mock<ITokenGenerator> _tokenGenerator;
        private MinifyController _minifyController;

        private readonly string _token = Guid.NewGuid().ToString();

        public MinifyControllerDeleteTest()
        {
            _repo = new Mock<IRepository>();
            _tokenGenerator = new Mock<ITokenGenerator>();
            _minifyController = new MinifyController(_repo.Object, _tokenGenerator.Object);
            
            _repo.Setup(a => a.Delete(_token));
        }
        
        [Fact]
        public void ReturnDelete()
        {
            _minifyController.Delete(_token);

            _repo.Verify(a => a.Delete(_token));
        }
    }
}