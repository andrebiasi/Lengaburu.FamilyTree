using Lengaburu.FamilyTree.Core.Model;
using System.Collections.Generic;

namespace Lengaburu.FamilyTree.Core.Interfaces
{
    public interface IFamilyBuilder
    {
        void AddFamilyMember(Person person, List<Relationship> relationships);
    }
}