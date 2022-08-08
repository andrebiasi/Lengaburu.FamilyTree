using Lengaburu.FamilyTree.ConsoleApp.Interfaces;
using Lengaburu.FamilyTree.Core.Interfaces;
using Lengaburu.FamilyTree.Services.Factories;
using System.Collections.Generic;
using System.Linq;

namespace Lengaburu.FamilyTree.ConsoleApp
{
    public class FamilyProcessor
    {
        private ITransactionImporter transactionImporter;
        private IOutputExporter outputExporter;
        private IFamilyRepository familyRepository;
        private ITransactionFactory transactionFactory;

        public FamilyProcessor(ITransactionImporter transactionImporter, IOutputExporter outputExporter, IFamilyRepository familyRepository, ITransactionFactory transactionFactory)
        {
            this.transactionImporter = transactionImporter;
            this.outputExporter = outputExporter;
            this.familyRepository = familyRepository;
            this.transactionFactory = transactionFactory;
        }

        public void Execute()
        {
            var transactions = transactionImporter.GetAllTransactions();
            if (transactions == null)
                return;

            var outputs = new List<string>();

            foreach(var transaction in transactions)
            {
                var args = transaction.Split(" "); 

                var familyTransaction = transactionFactory.CreateTransaction(args);
                var result = familyTransaction.Execute();
                outputs.Add(result);
            }

            if (outputs.Any())
                outputExporter.Export(outputs);
        }
    }
}