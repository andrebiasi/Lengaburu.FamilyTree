using FluentAssertions;
using Lengaburu.FamilyTree.Core.Interfaces;
using Lengaburu.FamilyTree.Core.Model;
using Moq;
using System.Collections.Generic;
using Xunit;
using static Lengaburu.FamilyTree.Core.Enums.GenderEnum;
using static Lengaburu.FamilyTree.Core.Enums.RelationshipEnum;

namespace Lengaburu.FamilyTree.Services.UnitTests
{
    public class NullSearcherTests
    {
        [Fact]
        public void ShouldReturnEmptyList()
        {
            var person = new Person("Bob", Gender.Male);

            var searcher = new NullSearcher();
            var results = searcher.FindAll(person);

            results.Should().BeEmpty();
        }
    }
}