using Lengaburu.FamilyTree.Core.Interfaces;
using Lengaburu.FamilyTree.Core.Model;
using System.Collections.Generic;
using System.Linq;
using static Lengaburu.FamilyTree.Core.Enums.GenderEnum;
using static Lengaburu.FamilyTree.Core.Enums.RelationshipEnum;

namespace Lengaburu.FamilyTree.Services
{
    public class SisterInLawSearcher : IRelationshipSearcher
    {
        private IFamilyRepository familyRepository;

        public SisterInLawSearcher(IFamilyRepository familyRepository)
        {
            this.familyRepository = familyRepository;
        }

        public List<Person> FindAll(Person person)
        {
            var relationships = familyRepository.FindAllRelationships(person?.Name);

            var spouse = relationships
                .Where(r => r.RelationshipType == RelationshipType.Spouse)
                .Select(r => r.PersonB)
                .FirstOrDefault();

            var spousesRelationships = familyRepository.FindAllRelationships(spouse?.Name).ToList();

            var spousesSisters = spousesRelationships
                .Where(f => f.RelationshipType == RelationshipType.Sibling && f.PersonB.Gender == Gender.Female)
                .Select(f => f.PersonB)
                .ToList();

            var siblings = relationships
                .Where(r => r.RelationshipType == RelationshipType.Sibling)
                .Select(r => r.PersonB)
                .ToList();

            var siblingsRelationships = siblings
                .SelectMany(s => familyRepository
                .FindAllRelationships(s.Name))
                .ToList();

            var wivesOfSiblings = siblingsRelationships
                .Where(s => s.RelationshipType == RelationshipType.Spouse && s.PersonB.Gender == Gender.Female)
                .Select(s => s.PersonB)
                .ToList();

            var sistersInLaw = spousesSisters
                .Union(wivesOfSiblings)
                .ToList();

            return sistersInLaw;
        }
    }
}
