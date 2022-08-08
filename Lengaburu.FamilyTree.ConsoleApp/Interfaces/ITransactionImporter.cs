using System.Collections.Generic;

namespace Lengaburu.FamilyTree.ConsoleApp.Interfaces
{
    public interface ITransactionImporter
    {
        List<string> GetAllTransactions();
    }
}