using Lengaburu.FamilyTree.Core.Interfaces;
using Lengaburu.FamilyTree.Core.Model;
using System.Collections.Generic;
using System.Linq;
using static Lengaburu.FamilyTree.Core.Enums.GenderEnum;
using static Lengaburu.FamilyTree.Core.Enums.RelationshipEnum;

namespace Lengaburu.FamilyTree.Services
{
    public class SonSearcher : IRelationshipSearcher
    {
        private IFamilyRepository familyRepository;

        public SonSearcher(IFamilyRepository familyRepository)
        {
            this.familyRepository = familyRepository;
        }

        public List<Person> FindAll(Person person)
        {
            var relationships = familyRepository.FindAllRelationships(person?.Name);

            var sons = relationships
                .Where(f => f.RelationshipType == RelationshipType.Parent && f.PersonB.Gender == Gender.Male)
                .Select(f => f.PersonB)
                .ToList();

            return sons;
        }
    }
}