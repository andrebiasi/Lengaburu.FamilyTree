using Lengaburu.FamilyTree.Core.Interfaces;

namespace Lengaburu.FamilyTree.Services.Factories
{
    public interface ISearcherFactory
    {
        IRelationshipSearcher CreateSearcher(string relationship);
    }
}
