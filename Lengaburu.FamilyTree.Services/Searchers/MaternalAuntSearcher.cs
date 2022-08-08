using Lengaburu.FamilyTree.Core.Interfaces;
using Lengaburu.FamilyTree.Core.Model;
using System.Collections.Generic;
using System.Linq;
using static Lengaburu.FamilyTree.Core.Enums.GenderEnum;
using static Lengaburu.FamilyTree.Core.Enums.RelationshipEnum;

namespace Lengaburu.FamilyTree.Services
{
    public class MaternalAuntSearcher : IRelationshipSearcher
    {
        private IFamilyRepository familyRepository;

        public MaternalAuntSearcher(IFamilyRepository familyRepository)
        {
            this.familyRepository = familyRepository;
        }

        public List<Person> FindAll(Person person)
        {
            var relationships = familyRepository.FindAllRelationships(person?.Name);

            var mother = relationships
                .Where(r => r.RelationshipType == RelationshipType.Child && r.PersonB.Gender == Gender.Female)
                .Select(r => r.PersonB)
                .FirstOrDefault();

            var mothersRelationships = familyRepository.FindAllRelationships(mother?.Name).ToList();

            var maternallUncles = mothersRelationships
                .Where(f => f.RelationshipType == RelationshipType.Sibling && f.PersonB.Gender == Gender.Female)
                .Select(f => f.PersonB)
                .ToList();

            return maternallUncles;
        }
    }
}