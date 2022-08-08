using Lengaburu.FamilyTree.ConsoleApp.Interfaces;
using System;
using System.Collections.Generic;

namespace Lengaburu.FamilyTree.ConsoleApp
{
    public class ConsoleOutputExporter : IOutputExporter
    {
        public void Export(List<string> outputs)
        {
            if (outputs == null)
                return;

            foreach(var output in outputs)
            {
                Console.WriteLine(output);
            }
        }
    }
}