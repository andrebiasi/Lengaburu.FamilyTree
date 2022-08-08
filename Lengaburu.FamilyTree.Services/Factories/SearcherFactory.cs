using Lengaburu.FamilyTree.Core.Interfaces;

namespace Lengaburu.FamilyTree.Services.Factories
{
    public class SearcherFactory : ISearcherFactory
    {
        private IFamilyRepository familyRepository;

        public SearcherFactory(IFamilyRepository familyRepository)
        {
            this.familyRepository = familyRepository;
        }

        public IRelationshipSearcher CreateSearcher(string relationship)
        {
            switch (relationship.ToLower())
            {
                case "paternal-uncle":
                    return new PaternalUncleSearcher(familyRepository);
                case "maternal-uncle":
                    return new MaternalUncleSearcher(familyRepository);
                case "paternal-aunt":
                    return new PaternalAuntSearcher(familyRepository);
                case "maternal-aunt":
                    return new MaternalAuntSearcher(familyRepository);
                case "sister-in-law":
                    return new SisterInLawSearcher(familyRepository);
                case "brother-in-law":
                    return new BrotherInLawSearcher(familyRepository);
                case "son":
                    return new SonSearcher(familyRepository);
                case "daughter":
                    return new DaughterSearcher(familyRepository);
                case "siblings":
                    return new SiblingSearcher(familyRepository);
                default:
                    return new NullSearcher();
            }
        }
    }
}