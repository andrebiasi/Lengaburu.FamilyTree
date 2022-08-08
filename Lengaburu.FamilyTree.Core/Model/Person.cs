using static Lengaburu.FamilyTree.Core.Enums.GenderEnum;

namespace Lengaburu.FamilyTree.Core.Model
{
    public class Person
    {
        public string Name { get; private set; }
        public Gender Gender { get; private set; }

        public Person(string name, Gender gender)
        {
            Name = name;
            Gender = gender;
        }
    }
}