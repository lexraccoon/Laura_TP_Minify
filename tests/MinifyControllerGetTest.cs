using Xunit;
using Bogus;
using System.Linq;
using Minify.Controllers;
using Minify.Interfaces;
using Minify.Model;
using Moq;

namespace Minify.Tests
{
    public class MinifyControllerGetTest
    {
        private readonly Mock<IRepository> _repo;
        private readonly Mock<ITokenGenerator> _tokenGenerator;
        private MinifyController _minifyController;

        public MinifyControllerGetTest()
        {
            _repo = new Mock<IRepository>();
            _tokenGenerator = new Mock<ITokenGenerator>();
            _minifyController = new MinifyController(_repo.Object, _tokenGenerator.Object);

            _repo.Setup(a => a.Get());
        }
        
        [Fact]
        public void ReturnGetAllCollection()
        {
            _minifyController.Get();
            
            _repo.Verify(a => a.Get());
            
        }
    }
}