using System;
using System.Linq;
using Bogus;
using Minify.Model;
using Xunit;

namespace Minify.Tests
{
    public class RepoTest
    {
        Repository repo;

        public RepoTest()
        {
            repo = new Repository();
            Repository.collection = new Faker<MinifyData>()
                .RuleFor(property => property.Url, faker => faker.Internet.Url())
                .RuleFor(property => property.Key, faker => faker.Lorem.Word())
                .Generate(5);
        }
        
        [Fact]
        public void Add()
        {
            var a = new Faker<MinifyData>()
                .RuleFor(property => property.Url, faker => faker.Internet.Url())
                .RuleFor(property => property.Key, faker => faker.Lorem.Word())
                .Generate();
            
            repo.Add(a);
            
            Assert.Equal(6, Repository.collection.Count());
            Assert.Contains(a, Repository.collection);
        }
        
        [Fact]
        public void Delete()
        {
            var d = Repository.collection.FirstOrDefault();
            
            repo.Delete(d.Key);

            Assert.Equal(4, Repository.collection.Count());
            Assert.DoesNotContain(d, Repository.collection);
        }
        
        [Fact]
        public void Get()
        {
            var g = repo.Get();
            
            Assert.Equal(g, Repository.collection);
        }
        
        [Fact]
        public void GetOneKey()
        {
            var g = repo.Get(Repository.collection.FirstOrDefault().Key);
            
            Assert.Equal(g, Repository.collection.FirstOrDefault());
        }
    }
}
