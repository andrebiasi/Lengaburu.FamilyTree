using Lengaburu.FamilyTree.Core.Interfaces;
using Lengaburu.FamilyTree.Services.Transactions;
using System.Linq;

namespace Lengaburu.FamilyTree.Services.Factories
{
    public class TransactionFactory : ITransactionFactory
    {
        private IFamilyRepository familyRepository;
        private ISearcherFactory searcherFactory;

        public TransactionFactory(IFamilyRepository familyRepository, ISearcherFactory searcherFactory)
        {
            this.familyRepository = familyRepository;
            this.searcherFactory = searcherFactory;
        }

        public IFamilyTransaction CreateTransaction(string[] args)
        {
            if (!args.Any())
                return new InvalidTransaction();

            var command = args[0].Trim();

            switch (command.ToLower())
            {
                case "add_child":
                    if (args.Length != 4)
                        return new InvalidTransaction();

                    var mothersName = args[1].Trim();
                    var childsName = args[2].Trim();
                    var childsGender = args[3].Trim();

                    return new AddChildTransaction(familyRepository, mothersName, childsName, childsGender);

                case "get_relationship":
                    if (args.Length != 3)
                        return new InvalidTransaction();

                    var name = args[1].Trim();
                    var relationship = args[2].Trim();

                    return new GetRelationshipTransaction(familyRepository, searcherFactory, name, relationship);

                default:
                    return new InvalidTransaction();
            }
        }
    }
}