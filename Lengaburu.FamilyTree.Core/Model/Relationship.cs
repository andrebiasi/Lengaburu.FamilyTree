using static Lengaburu.FamilyTree.Core.Enums.RelationshipEnum;

namespace Lengaburu.FamilyTree.Core.Model
{
    public class Relationship
    {
        public Person PersonA { get; private set; }
        public RelationshipType RelationshipType { get; private set; }
        public Person PersonB { get; private set; }

        public Relationship(Person personA, RelationshipType relationshipType, Person personB)
        {
            PersonA = personA;
            RelationshipType = relationshipType;
            PersonB = personB;
        }
    }
}