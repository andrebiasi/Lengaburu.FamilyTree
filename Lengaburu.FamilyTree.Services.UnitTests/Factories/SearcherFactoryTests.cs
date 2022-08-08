using FluentAssertions;
using Lengaburu.FamilyTree.Core.Interfaces;
using Lengaburu.FamilyTree.Services.Factories;
using Moq;
using System;
using Xunit;

namespace Lengaburu.FamilyTree.Services.UnitTests
{
    public class SearcherFactoryTests
    {
        [Theory]
        [InlineData("paternal-uncle", typeof(PaternalUncleSearcher))]
        [InlineData("maternal-uncle", typeof(MaternalUncleSearcher))]
        [InlineData("paternal-aunt", typeof(PaternalAuntSearcher))]
        [InlineData("maternal-aunt", typeof(MaternalAuntSearcher))]
        [InlineData("sister-in-law", typeof(SisterInLawSearcher))]
        [InlineData("brother-in-law", typeof(BrotherInLawSearcher))]
        [InlineData("son", typeof(SonSearcher))]
        [InlineData("daughter", typeof(DaughterSearcher))]
        [InlineData("invalid", typeof(NullSearcher))]

        public void ShouldCreateRelationshipSearcher(string relationship, Type type)
        {
            var familyRepositoryMock = new Mock<IFamilyRepository>();

            var searcherFactory = new SearcherFactory(familyRepositoryMock.Object);
            var searcher = searcherFactory.CreateSearcher(relationship);

            searcher.Should().BeOfType(type);
        }
    }
}