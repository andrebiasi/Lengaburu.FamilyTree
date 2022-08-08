using Lengaburu.FamilyTree.Core.Model;
using System.Collections.Generic;

namespace Lengaburu.FamilyTree.Core.Interfaces
{
    public interface IRelationshipSearcher
    {
        List<Person> FindAll(Person person);
    }
}