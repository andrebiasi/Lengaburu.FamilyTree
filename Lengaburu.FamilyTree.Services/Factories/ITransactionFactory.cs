using Lengaburu.FamilyTree.Core.Interfaces;

namespace Lengaburu.FamilyTree.Services.Factories
{
    public interface ITransactionFactory
    {
        IFamilyTransaction CreateTransaction(string[] args);
    }
}