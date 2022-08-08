using Lengaburu.FamilyTree.Core.Model;
using System.Collections.Generic;

namespace Lengaburu.FamilyTree.Core.Interfaces
{
    public interface IFamilyRepository
    {
        void AddPerson(Person person);
        void AddRelationship(Relationship relationship);
        Person FindPersonByName(string name);
        List<Person> FindAll();
        List<Relationship> FindAllRelationships(string name);
    }
}