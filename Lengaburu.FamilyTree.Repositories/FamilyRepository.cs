using Lengaburu.FamilyTree.Core.Interfaces;
using Lengaburu.FamilyTree.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Lengaburu.FamilyTree.Repositories
{
    public class FamilyRepository : IFamilyRepository
    {
        private List<Person> familyMembers;
        private List<Relationship> relationships;

        public FamilyRepository()
        {
            familyMembers = new List<Person>();
            relationships = new List<Relationship>();
        }

        public void AddPerson(Person person)
        {
            if (person == null)
                return;

            var name = person.Name;
            if (IsPartOfFamily(name))
                return;

            familyMembers.Add(person);
        }

        public List<Person> FindAll()
        {
            return familyMembers;
        }

        public List<Relationship> FindAllRelationships(string name)
        {
            var relationships = this.relationships.Where(r => r.PersonA.Name == name);
            return relationships.ToList();
        }

        public Person FindPersonByName(string name)
        {
            return familyMembers.Where(f => f.Name == name).FirstOrDefault();
        }

        public void AddRelationship(Relationship relationship)
        {
            if (relationship?.PersonA == null || relationship?.PersonB == null)
                return;

            if (!IsPartOfFamily(relationship.PersonA.Name) ||
                !IsPartOfFamily(relationship.PersonB.Name))
                return;

            relationships.Add(relationship);
        }

        private bool IsPartOfFamily(string name)
        {
            return familyMembers.Where(f => f.Name == name).Any();
        }

    }
}