using Lengaburu.FamilyTree.Core.Interfaces;

namespace Lengaburu.FamilyTree.Services.Transactions
{
    public class InvalidTransaction : IFamilyTransaction
    {
        public string Execute()
        {
            return "INVALID_TRANSACTION";
        }
    }
}