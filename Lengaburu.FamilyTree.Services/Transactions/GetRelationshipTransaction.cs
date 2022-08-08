using Lengaburu.FamilyTree.Core.Interfaces;
using Lengaburu.FamilyTree.Services.Factories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Lengaburu.FamilyTree.Services.Transactions
{
    public class GetRelationshipTransaction : IFamilyTransaction
    {
        private const string PERSON_NOT_FOUND = "PERSON_NOT_FOUND";
        private const string NONE = "NONE";

        private IFamilyRepository familyRepository;
        private ISearcherFactory searcherFactory;
        private string name;
        private string relationship;

        public GetRelationshipTransaction(IFamilyRepository familyRepository, ISearcherFactory searcherFactory, string name, string relationship)
        {
            this.familyRepository = familyRepository;
            this.searcherFactory = searcherFactory;
            this.name = name;
            this.relationship = relationship;
        }

        public string Execute()
        {
            var outputs = new List<string>();

            var person = familyRepository.FindPersonByName(name);
            if (person == null)
                return PERSON_NOT_FOUND;

            var searcher = searcherFactory.CreateSearcher(relationship);
            var relationships = searcher.FindAll(person);
                
            if (relationships.Any())
            {
                var relatives = relationships.Select(r => r.Name);
                return string.Join(" ", relatives);
            }
            else
            {
                return NONE;
            }
        }
    }
}