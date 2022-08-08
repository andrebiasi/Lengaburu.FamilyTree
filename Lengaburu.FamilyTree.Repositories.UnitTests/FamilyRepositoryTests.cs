using FluentAssertions;
using Lengaburu.FamilyTree.Core.Model;
using System.Linq;
using Xunit;
using static Lengaburu.FamilyTree.Core.Enums.GenderEnum;
using static Lengaburu.FamilyTree.Core.Enums.RelationshipEnum;

namespace Lengaburu.FamilyTree.Repositories.UnitTests
{
    public class FamilyRepositoryTests
    {
        [Fact]
        public void ShouldAddPerson()
        {
            var name = "Bob";
            var person = new Person(name, Gender.Male);

            var familyRepository = new FamilyRepository();
            familyRepository.AddPerson(person);

            var result = familyRepository.FindPersonByName(name);
            result.Should().BeEquivalentTo(person);
        }

        [Fact]
        public void ShouldNotAddAgainWhenPersonAlreadyPartOfFamily()
        {
            var name = "Bob";
            var person = new Person(name, Gender.Male);

            var familyRepository = new FamilyRepository();
            familyRepository.AddPerson(person);
            familyRepository.AddPerson(person);

            var results = familyRepository.FindAll();
            results.Count().Should().Be(1);
        }

        [Fact]
        public void ShouldIgnoreWhenNullProvided()
        {
            var familyRepository = new FamilyRepository();
            familyRepository.AddPerson(null);

            var results = familyRepository.FindAll();
            results.Should().BeEmpty();
        }

        [Fact]
        public void ShouldReturnNullWhenPersonNotFound()
        {
            var name = "Bob";

            var familyRepository = new FamilyRepository();
            familyRepository.FindPersonByName(name);

            var result = familyRepository.FindPersonByName(name);
            result.Should().BeNull();
        }

        [Fact]
        public void ShouldReturnEmptyListWhenNoFamilyMembers()
        {
            var familyRepository = new FamilyRepository();

            var results = familyRepository.FindAll();
            results.Should().BeEmpty();
        }

        [Fact]
        public void ShouldReturnEmptyListWhenNoRelationshipFound()
        {
            var name = "Bob";

            var familyRepository = new FamilyRepository();
            var results = familyRepository.FindAllRelationships(name);

            results.Should().BeEmpty();
        }

        [Fact]
        public void ShouldReturnEmptyListWhenFindingRelationshipsWhenNullGiven()
        {
            string name = null;

            var familyRepository = new FamilyRepository();
            var results = familyRepository.FindAllRelationships(name);

            results.Should().BeEmpty();
        }

        [Fact]
        public void ShouldAddRelationshipsWhenPeopleFound()
        {
            var personA = new Person("Bob", Gender.Male);
            var personB = new Person("Mary", Gender.Female);
            var relationship = new Relationship(personA, RelationshipType.Spouse, personB);

            var familyRepository = new FamilyRepository();
            familyRepository.AddPerson(personA);
            familyRepository.AddPerson(personB);
            familyRepository.AddRelationship(relationship);

            var relationships = familyRepository.FindAllRelationships(personA.Name);
            relationships.First().Should().BeEquivalentTo(relationship);
        }

        [Fact]
        public void ShouldNotAddRelationshipWhenPersonANotFound()
        {
            var personA = new Person("Bob", Gender.Male);
            var personB = new Person("Mary", Gender.Female);
            var relationship = new Relationship(personA, RelationshipType.Spouse, personB);

            
            var familyRepository = new FamilyRepository();
            familyRepository.AddPerson(personB);
            familyRepository.AddRelationship(relationship);

            var relationships = familyRepository.FindAllRelationships(personA.Name);
            relationships.Should().BeEmpty();
        }

        [Fact]
        public void ShouldNotAddRelationshipWhenPersonBNotFound()
        {
            var personA = new Person("Bob", Gender.Male);
            var personB = new Person("Mary", Gender.Female);
            var relationship = new Relationship(personA, RelationshipType.Spouse, personB);


            var familyRepository = new FamilyRepository();
            familyRepository.AddPerson(personA);
            familyRepository.AddRelationship(relationship);

            var relationships = familyRepository.FindAllRelationships(personA.Name);
            relationships.Should().BeEmpty();
        }

        [Fact]
        public void ShouldNotAddRelationshipWhenPersonAIsNull()
        {
            var personA = new Person("Bob", Gender.Male); ;
            var personB = new Person("Mary", Gender.Female);
            var relationship = new Relationship(null, RelationshipType.Spouse, personB);


            var familyRepository = new FamilyRepository();
            familyRepository.AddPerson(personA);
            familyRepository.AddPerson(personB);
            familyRepository.AddRelationship(relationship);

            var relationships = familyRepository.FindAllRelationships(personA.Name);
            relationships.Should().BeEmpty();
        }

        [Fact]
        public void ShouldNotAddRelationshipWhenPersonBIsNull()
        {
            var personA = new Person("Bob", Gender.Male);
            var personB = new Person("Mary", Gender.Female);
            var relationship = new Relationship(personA, RelationshipType.Spouse, null);


            var familyRepository = new FamilyRepository();
            familyRepository.AddPerson(personA);
            familyRepository.AddPerson(personB);
            familyRepository.AddRelationship(relationship);

            var relationships = familyRepository.FindAllRelationships(personA.Name);
            relationships.Should().BeEmpty();
        }
    }
}