using Lengaburu.FamilyTree.Core.Interfaces;
using Lengaburu.FamilyTree.Core.Model;
using System.Collections.Generic;
using System.Linq;

namespace Lengaburu.FamilyTree.Services
{
    public class NullSearcher : IRelationshipSearcher
    {
        public List<Person> FindAll(Person person)
        {
            return new List<Person>();
        }
    }
}