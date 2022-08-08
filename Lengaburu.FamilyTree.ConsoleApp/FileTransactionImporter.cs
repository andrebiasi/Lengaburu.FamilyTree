using Lengaburu.FamilyTree.ConsoleApp.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Lengaburu.FamilyTree.ConsoleApp
{
    class FileTransactionImporter : ITransactionImporter
    {
        private string filePath;

        public FileTransactionImporter(string filePath)
        {
            this.filePath = filePath;
        }

        public List<string> GetAllTransactions()
        {
            try
            {
                return File.ReadAllLines(filePath).ToList();
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error trying to read input file {filePath}.", ex);
            }
        }
    }
}