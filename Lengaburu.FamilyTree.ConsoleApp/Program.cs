using CommandLine;
using Lengaburu.FamilyTree.Core.Interfaces;
using Lengaburu.FamilyTree.Core.Model;
using Lengaburu.FamilyTree.Repositories;
using Lengaburu.FamilyTree.Services.Factories;
using static Lengaburu.FamilyTree.Core.Enums.GenderEnum;
using static Lengaburu.FamilyTree.Core.Enums.RelationshipEnum;

namespace Lengaburu.FamilyTree.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Parser.Default.ParseArguments<Options>(args)
                .WithParsed(opts =>
                {
                    var inputFilePath = opts.InputFile;

                    var fileTransactionImporter = new FileTransactionImporter(inputFilePath);
                    var consoleOutputExporter = new ConsoleOutputExporter();
                    var familyRepository = CreateAndLoadFamilyRepository();
                    var searcherFactory = new SearcherFactory(familyRepository);
                    var transactionFactory = new TransactionFactory(familyRepository, searcherFactory);

                    var familyProcessor = new FamilyProcessor(fileTransactionImporter, consoleOutputExporter, familyRepository, transactionFactory);
                    familyProcessor.Execute();
                });
        }

        private static IFamilyRepository CreateAndLoadFamilyRepository()
        {
            var familyRepository = new FamilyRepository();

            #region family members
            var kingArthur = new Person("Arthur", Gender.Male);
            var queenMargret = new Person("Margret", Gender.Female);
            var bill = new Person("Bill", Gender.Male);
            var flora = new Person("Flora", Gender.Female);
            var charlie = new Person("Charlie", Gender.Male);
            var percy = new Person("Percy", Gender.Male);
            var audrey = new Person("Audrey", Gender.Female);
            var ronald = new Person("Ronald", Gender.Male);
            var helen = new Person("Helen", Gender.Female);
            var ginerva = new Person("Ginerva", Gender.Female);
            var harry = new Person("Harry", Gender.Male);
            var victoire = new Person("Victoire", Gender.Female);
            var ted = new Person("Ted", Gender.Male);
            var dominique = new Person("Dominique", Gender.Female);
            var louis = new Person("Louis", Gender.Male);
            var molly = new Person("Molly", Gender.Female);
            var lucy = new Person("Lucy", Gender.Female);
            var malfoy = new Person("Malfoy", Gender.Male);
            var rose = new Person("Rose", Gender.Female);
            var hugo = new Person("Hugo", Gender.Male);
            var darcy = new Person("Darcy", Gender.Female);
            var james = new Person("James", Gender.Male);
            var alice = new Person("Alice", Gender.Female);
            var albus = new Person("Albus", Gender.Male);
            var lily = new Person("Lily", Gender.Female);
            var remus = new Person("Remus", Gender.Male);
            var draco = new Person("Draco", Gender.Male);
            var aster = new Person("Aster", Gender.Female);
            var william = new Person("William", Gender.Male);
            var ron = new Person("Ron", Gender.Male);
            var ginny = new Person("Ginny", Gender.Female);
            #endregion

            #region add people
            familyRepository.AddPerson(kingArthur);
            familyRepository.AddPerson(queenMargret);
            familyRepository.AddPerson(bill);
            familyRepository.AddPerson(flora);
            familyRepository.AddPerson(charlie);
            familyRepository.AddPerson(percy);
            familyRepository.AddPerson(audrey);
            familyRepository.AddPerson(ronald);
            familyRepository.AddPerson(helen);
            familyRepository.AddPerson(ginerva);
            familyRepository.AddPerson(harry);
            familyRepository.AddPerson(victoire);
            familyRepository.AddPerson(ted);
            familyRepository.AddPerson(dominique);
            familyRepository.AddPerson(louis);
            familyRepository.AddPerson(molly);
            familyRepository.AddPerson(lucy);
            familyRepository.AddPerson(malfoy);
            familyRepository.AddPerson(rose);
            familyRepository.AddPerson(hugo);
            familyRepository.AddPerson(darcy);
            familyRepository.AddPerson(james);
            familyRepository.AddPerson(alice);
            familyRepository.AddPerson(albus);
            familyRepository.AddPerson(lily);
            familyRepository.AddPerson(remus);
            familyRepository.AddPerson(draco);
            familyRepository.AddPerson(aster);
            familyRepository.AddPerson(william);
            familyRepository.AddPerson(ron);
            familyRepository.AddPerson(ginny);
            #endregion

            #region add relationships
            // King Arthur
            familyRepository.AddRelationship(new Relationship(kingArthur, RelationshipType.Spouse, queenMargret));
            familyRepository.AddRelationship(new Relationship(kingArthur, RelationshipType.Parent, bill));
            familyRepository.AddRelationship(new Relationship(kingArthur, RelationshipType.Parent, charlie));
            familyRepository.AddRelationship(new Relationship(kingArthur, RelationshipType.Parent, percy));
            familyRepository.AddRelationship(new Relationship(kingArthur, RelationshipType.Parent, ronald));
            familyRepository.AddRelationship(new Relationship(kingArthur, RelationshipType.Parent, ginerva));

            // Queen Margret
            familyRepository.AddRelationship(new Relationship(queenMargret, RelationshipType.Spouse, kingArthur));
            familyRepository.AddRelationship(new Relationship(queenMargret, RelationshipType.Parent, bill));
            familyRepository.AddRelationship(new Relationship(queenMargret, RelationshipType.Parent, charlie));
            familyRepository.AddRelationship(new Relationship(queenMargret, RelationshipType.Parent, percy));
            familyRepository.AddRelationship(new Relationship(queenMargret, RelationshipType.Parent, ronald));
            familyRepository.AddRelationship(new Relationship(queenMargret, RelationshipType.Parent, ginerva));

            // Bill
            familyRepository.AddRelationship(new Relationship(bill, RelationshipType.Child, kingArthur));
            familyRepository.AddRelationship(new Relationship(bill, RelationshipType.Child, queenMargret));
            familyRepository.AddRelationship(new Relationship(bill, RelationshipType.Spouse, flora));
            familyRepository.AddRelationship(new Relationship(bill, RelationshipType.Sibling, charlie));
            familyRepository.AddRelationship(new Relationship(bill, RelationshipType.Sibling, percy));
            familyRepository.AddRelationship(new Relationship(bill, RelationshipType.Sibling, ronald));
            familyRepository.AddRelationship(new Relationship(bill, RelationshipType.Sibling, ginerva));
            familyRepository.AddRelationship(new Relationship(bill, RelationshipType.Parent, victoire));
            familyRepository.AddRelationship(new Relationship(bill, RelationshipType.Parent, dominique));
            familyRepository.AddRelationship(new Relationship(bill, RelationshipType.Parent, louis));

            // Flora
            familyRepository.AddRelationship(new Relationship(flora, RelationshipType.Spouse, bill));
            familyRepository.AddRelationship(new Relationship(flora, RelationshipType.Parent, victoire));
            familyRepository.AddRelationship(new Relationship(flora, RelationshipType.Parent, dominique));
            familyRepository.AddRelationship(new Relationship(flora, RelationshipType.Parent, louis));

            // Charlie
            familyRepository.AddRelationship(new Relationship(charlie, RelationshipType.Child, kingArthur));
            familyRepository.AddRelationship(new Relationship(charlie, RelationshipType.Child, queenMargret));
            familyRepository.AddRelationship(new Relationship(charlie, RelationshipType.Sibling, bill));
            familyRepository.AddRelationship(new Relationship(charlie, RelationshipType.Sibling, percy));
            familyRepository.AddRelationship(new Relationship(charlie, RelationshipType.Sibling, ronald));
            familyRepository.AddRelationship(new Relationship(charlie, RelationshipType.Sibling, ginerva));

            // Percy
            familyRepository.AddRelationship(new Relationship(percy, RelationshipType.Child, kingArthur));
            familyRepository.AddRelationship(new Relationship(percy, RelationshipType.Child, queenMargret));
            familyRepository.AddRelationship(new Relationship(percy, RelationshipType.Spouse, audrey));
            familyRepository.AddRelationship(new Relationship(percy, RelationshipType.Sibling, bill));
            familyRepository.AddRelationship(new Relationship(percy, RelationshipType.Sibling, charlie));
            familyRepository.AddRelationship(new Relationship(percy, RelationshipType.Sibling, ronald));
            familyRepository.AddRelationship(new Relationship(percy, RelationshipType.Sibling, ginerva));
            familyRepository.AddRelationship(new Relationship(percy, RelationshipType.Parent, molly));
            familyRepository.AddRelationship(new Relationship(percy, RelationshipType.Parent, lucy));

            // Audrey
            familyRepository.AddRelationship(new Relationship(audrey, RelationshipType.Spouse, percy));
            familyRepository.AddRelationship(new Relationship(audrey, RelationshipType.Parent, molly));
            familyRepository.AddRelationship(new Relationship(audrey, RelationshipType.Parent, lucy));

            // Ronald
            familyRepository.AddRelationship(new Relationship(ronald, RelationshipType.Child, kingArthur));
            familyRepository.AddRelationship(new Relationship(ronald, RelationshipType.Child, queenMargret));
            familyRepository.AddRelationship(new Relationship(ronald, RelationshipType.Spouse, helen));
            familyRepository.AddRelationship(new Relationship(ronald, RelationshipType.Sibling, bill));
            familyRepository.AddRelationship(new Relationship(ronald, RelationshipType.Sibling, charlie));
            familyRepository.AddRelationship(new Relationship(ronald, RelationshipType.Sibling, percy));
            familyRepository.AddRelationship(new Relationship(ronald, RelationshipType.Sibling, ginerva));
            familyRepository.AddRelationship(new Relationship(ronald, RelationshipType.Parent, rose));
            familyRepository.AddRelationship(new Relationship(ronald, RelationshipType.Parent, hugo));

            // Helen
            familyRepository.AddRelationship(new Relationship(helen, RelationshipType.Spouse, ronald));
            familyRepository.AddRelationship(new Relationship(helen, RelationshipType.Parent, rose));
            familyRepository.AddRelationship(new Relationship(helen, RelationshipType.Parent, hugo));

            // Ginerva
            familyRepository.AddRelationship(new Relationship(ginerva, RelationshipType.Child, kingArthur));
            familyRepository.AddRelationship(new Relationship(ginerva, RelationshipType.Child, queenMargret));
            familyRepository.AddRelationship(new Relationship(ginerva, RelationshipType.Spouse, harry));
            familyRepository.AddRelationship(new Relationship(ginerva, RelationshipType.Sibling, bill));
            familyRepository.AddRelationship(new Relationship(ginerva, RelationshipType.Sibling, charlie));
            familyRepository.AddRelationship(new Relationship(ginerva, RelationshipType.Sibling, percy));
            familyRepository.AddRelationship(new Relationship(ginerva, RelationshipType.Sibling, ronald));
            familyRepository.AddRelationship(new Relationship(ginerva, RelationshipType.Parent, james));
            familyRepository.AddRelationship(new Relationship(ginerva, RelationshipType.Parent, albus));
            familyRepository.AddRelationship(new Relationship(ginerva, RelationshipType.Parent, lily));

            // Harry
            familyRepository.AddRelationship(new Relationship(harry, RelationshipType.Spouse, ginerva));
            familyRepository.AddRelationship(new Relationship(harry, RelationshipType.Parent, james));
            familyRepository.AddRelationship(new Relationship(harry, RelationshipType.Parent, albus));
            familyRepository.AddRelationship(new Relationship(harry, RelationshipType.Parent, lily));

            // Victoire
            familyRepository.AddRelationship(new Relationship(victoire, RelationshipType.Child, bill));
            familyRepository.AddRelationship(new Relationship(victoire, RelationshipType.Child, flora));
            familyRepository.AddRelationship(new Relationship(victoire, RelationshipType.Spouse, ted));
            familyRepository.AddRelationship(new Relationship(victoire, RelationshipType.Sibling, dominique));
            familyRepository.AddRelationship(new Relationship(victoire, RelationshipType.Sibling, louis));
            familyRepository.AddRelationship(new Relationship(victoire, RelationshipType.Parent, remus));

            // Ted
            familyRepository.AddRelationship(new Relationship(ted, RelationshipType.Spouse, victoire));
            familyRepository.AddRelationship(new Relationship(ted, RelationshipType.Parent, remus));

            // Dominique
            familyRepository.AddRelationship(new Relationship(dominique, RelationshipType.Child, bill));
            familyRepository.AddRelationship(new Relationship(dominique, RelationshipType.Child, flora));
            familyRepository.AddRelationship(new Relationship(dominique, RelationshipType.Sibling, victoire));
            familyRepository.AddRelationship(new Relationship(dominique, RelationshipType.Sibling, louis));

            // Louis
            familyRepository.AddRelationship(new Relationship(louis, RelationshipType.Child, bill));
            familyRepository.AddRelationship(new Relationship(louis, RelationshipType.Child, flora));
            familyRepository.AddRelationship(new Relationship(louis, RelationshipType.Sibling, victoire));
            familyRepository.AddRelationship(new Relationship(louis, RelationshipType.Sibling, dominique));

            // Molly
            familyRepository.AddRelationship(new Relationship(molly, RelationshipType.Child, percy));
            familyRepository.AddRelationship(new Relationship(molly, RelationshipType.Child, audrey));
            familyRepository.AddRelationship(new Relationship(molly, RelationshipType.Sibling, lucy));

            // Lucy
            familyRepository.AddRelationship(new Relationship(lucy, RelationshipType.Child, percy));
            familyRepository.AddRelationship(new Relationship(lucy, RelationshipType.Child, audrey));
            familyRepository.AddRelationship(new Relationship(lucy, RelationshipType.Sibling, molly));

            // Malfoy
            familyRepository.AddRelationship(new Relationship(malfoy, RelationshipType.Spouse, rose));
            familyRepository.AddRelationship(new Relationship(malfoy, RelationshipType.Parent, draco));
            familyRepository.AddRelationship(new Relationship(malfoy, RelationshipType.Parent, aster));

            // Rose
            familyRepository.AddRelationship(new Relationship(rose, RelationshipType.Child, ronald));
            familyRepository.AddRelationship(new Relationship(rose, RelationshipType.Child, helen));
            familyRepository.AddRelationship(new Relationship(rose, RelationshipType.Spouse, malfoy));
            familyRepository.AddRelationship(new Relationship(rose, RelationshipType.Sibling, hugo));
            familyRepository.AddRelationship(new Relationship(rose, RelationshipType.Parent, draco));
            familyRepository.AddRelationship(new Relationship(rose, RelationshipType.Parent, aster));

            // Hugo
            familyRepository.AddRelationship(new Relationship(hugo, RelationshipType.Child, ronald));
            familyRepository.AddRelationship(new Relationship(hugo, RelationshipType.Child, helen));
            familyRepository.AddRelationship(new Relationship(hugo, RelationshipType.Sibling, rose));

            // Darcy
            familyRepository.AddRelationship(new Relationship(darcy, RelationshipType.Spouse, james));
            familyRepository.AddRelationship(new Relationship(darcy, RelationshipType.Parent, william));

            // James
            familyRepository.AddRelationship(new Relationship(james, RelationshipType.Child, ginerva));
            familyRepository.AddRelationship(new Relationship(james, RelationshipType.Child, harry));
            familyRepository.AddRelationship(new Relationship(james, RelationshipType.Spouse, darcy));
            familyRepository.AddRelationship(new Relationship(james, RelationshipType.Sibling, albus));
            familyRepository.AddRelationship(new Relationship(james, RelationshipType.Sibling, lily));
            familyRepository.AddRelationship(new Relationship(james, RelationshipType.Parent, william));

            // Alice
            familyRepository.AddRelationship(new Relationship(alice, RelationshipType.Spouse, albus));
            familyRepository.AddRelationship(new Relationship(alice, RelationshipType.Parent, ron));
            familyRepository.AddRelationship(new Relationship(alice, RelationshipType.Parent, ginny));

            // Albus
            familyRepository.AddRelationship(new Relationship(albus, RelationshipType.Child, ginerva));
            familyRepository.AddRelationship(new Relationship(albus, RelationshipType.Child, harry));
            familyRepository.AddRelationship(new Relationship(albus, RelationshipType.Spouse, alice));
            familyRepository.AddRelationship(new Relationship(albus, RelationshipType.Sibling, james));
            familyRepository.AddRelationship(new Relationship(albus, RelationshipType.Sibling, lily));
            familyRepository.AddRelationship(new Relationship(albus, RelationshipType.Parent, ron));
            familyRepository.AddRelationship(new Relationship(albus, RelationshipType.Parent, ginny));

            // Lily
            familyRepository.AddRelationship(new Relationship(lily, RelationshipType.Child, ginerva));
            familyRepository.AddRelationship(new Relationship(lily, RelationshipType.Child, harry));
            familyRepository.AddRelationship(new Relationship(lily, RelationshipType.Sibling, james));
            familyRepository.AddRelationship(new Relationship(lily, RelationshipType.Sibling, albus));

            // Remus
            familyRepository.AddRelationship(new Relationship(remus, RelationshipType.Child, victoire));
            familyRepository.AddRelationship(new Relationship(remus, RelationshipType.Child, ted));

            // Draco
            familyRepository.AddRelationship(new Relationship(draco, RelationshipType.Child, malfoy));
            familyRepository.AddRelationship(new Relationship(draco, RelationshipType.Child, rose));
            familyRepository.AddRelationship(new Relationship(draco, RelationshipType.Sibling, aster));

            // Aster
            familyRepository.AddRelationship(new Relationship(aster, RelationshipType.Child, malfoy));
            familyRepository.AddRelationship(new Relationship(aster, RelationshipType.Child, rose));
            familyRepository.AddRelationship(new Relationship(aster, RelationshipType.Sibling, draco));

            // William
            familyRepository.AddRelationship(new Relationship(william, RelationshipType.Child, darcy));
            familyRepository.AddRelationship(new Relationship(william, RelationshipType.Child, james));

            // Ron
            familyRepository.AddRelationship(new Relationship(ron, RelationshipType.Child, alice));
            familyRepository.AddRelationship(new Relationship(ron, RelationshipType.Child, albus));
            familyRepository.AddRelationship(new Relationship(ron, RelationshipType.Sibling, ginny));

            // Ginny
            familyRepository.AddRelationship(new Relationship(ginny, RelationshipType.Child, alice));
            familyRepository.AddRelationship(new Relationship(ginny, RelationshipType.Child, albus));
            familyRepository.AddRelationship(new Relationship(ginny, RelationshipType.Sibling, ron));
            #endregion

            return familyRepository;
        }
    }
}