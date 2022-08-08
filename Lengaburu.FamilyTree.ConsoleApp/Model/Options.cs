using CommandLine;

namespace Lengaburu.FamilyTree.ConsoleApp
{
    public class Options
    {
        [Value(0, Required = true, HelpText = "Input file")]
        public string InputFile { get; set; }
    }
}