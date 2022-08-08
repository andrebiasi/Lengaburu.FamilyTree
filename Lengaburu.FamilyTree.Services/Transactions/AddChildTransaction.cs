using Lengaburu.FamilyTree.Core.Interfaces;
using Lengaburu.FamilyTree.Core.Model;
using System.Collections.Generic;
using System.Linq;
using static Lengaburu.FamilyTree.Core.Enums.GenderEnum;
using static Lengaburu.FamilyTree.Core.Enums.RelationshipEnum;

namespace Lengaburu.FamilyTree.Services.Transactions
{
    public class AddChildTransaction : IFamilyTransaction
    {
        private const string CHILD_ADDITION_FAILED = "CHILD_ADDITION_FAILED";
        private const string CHILD_ADDITION_SUCCEEDED = "CHILD_ADDITION_SUCCEEDED";
        private const string PERSON_NOT_FOUND = "PERSON_NOT_FOUND";

        private IFamilyRepository familyRepository;
        private string mothersName;
        private string childsName;
        private string childsGender;

        public AddChildTransaction(IFamilyRepository familyRepository, string mothersName, string childsName, string childsGender)
        {
            this.familyRepository = familyRepository;
            this.mothersName = mothersName;
            this.childsName = childsName;
            this.childsGender = childsGender;
        }

        public string Execute()
        {
            if (InvalidNames())
                return CHILD_ADDITION_FAILED;

            if (InvalidGender())
                return CHILD_ADDITION_FAILED;

            if (PersonAlreadyExists())
                return CHILD_ADDITION_FAILED;

            var mother = FindMother();
            if (mother == null)
                return PERSON_NOT_FOUND;

            if (mother.Gender != Gender.Female)
                return CHILD_ADDITION_FAILED;

            var child = CreateChild();
            familyRepository.AddPerson(child);

            AddRelationships(child, mother);

            return CHILD_ADDITION_SUCCEEDED;
        }

        private bool InvalidNames()
        {
            return string.IsNullOrWhiteSpace(mothersName) || string.IsNullOrWhiteSpace(childsName);
        }

        private bool InvalidGender()
        {
            return childsGender.ToLower() != "male" && childsGender.ToLower() != "female";
        }

        private bool PersonAlreadyExists()
        {
            var person = familyRepository.FindPersonByName(childsName);

            return person != null;
        }

        private Person FindMother()
        {
            return familyRepository.FindPersonByName(mothersName);
        }

        private Person CreateChild()
        {
            var childsGender = this.childsGender.ToLower() == "male" ? Gender.Male : Gender.Female;
            return new Person(childsName, childsGender);
        }

        private void AddRelationships(Person child, Person mother)
        {
            var relationships = BuildRelationships(child, mother);

            foreach (var relationship in relationships)
                familyRepository.AddRelationship(relationship);
        }

        private List<Relationship> BuildRelationships(Person person, Person mother)
        {
            var relationships = new List<Relationship>();

            relationships.Add(new Relationship(person, RelationshipType.Child, mother));
            relationships.Add(new Relationship(mother, RelationshipType.Parent, person));

            var mothersRelationships = familyRepository.FindAllRelationships(mothersName);

            var father = FindFather(mothersRelationships);
            if (father != null)
            {
                relationships.Add(new Relationship(person, RelationshipType.Child, father));
                relationships.Add(new Relationship(father, RelationshipType.Parent, person));
            }

            var siblings = FindSiblings(mothersRelationships);
            foreach (var child in siblings)
            {
                relationships.Add(new Relationship(person, RelationshipType.Sibling, child));
                relationships.Add(new Relationship(child, RelationshipType.Sibling, person));
            }

            return relationships;
        }

        private Person FindFather(List<Relationship> mothersRelationships)
        {
            var father = mothersRelationships
                .Where(m => m.RelationshipType == RelationshipType.Spouse)
                .Select(m => m.PersonB).FirstOrDefault();

            return father;
        }

        private List<Person> FindSiblings(List<Relationship> mothersRelationships)
        {
            var siblings = mothersRelationships
                .Where(m => m.RelationshipType == RelationshipType.Parent)
                .Select(m => m.PersonB)
                .ToList();

            return siblings; 
        }
    }
}