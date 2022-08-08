using System.Collections.Generic;

namespace Lengaburu.FamilyTree.ConsoleApp.Interfaces
{
    public interface IOutputExporter
    {
        void Export(List<string> outputs);
    }
}