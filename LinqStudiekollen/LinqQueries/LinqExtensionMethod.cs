using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqStudiekollen.LinqQueries
{
    class LinqExtensionMethod
    {
       public static void LinqExtensionRestriction(StudieContext context)
       {
            // Vi vill ha alla prov med UserId 3 som inte har ett ogitligt testId-värde (0). Här använder vi &&-operatorn i Where-Clausen.
            var query = context.Tests.Where(c => (c.Id != 0) && (c.UserId == 3));
        
            foreach (var x in query)
            {
                Console.WriteLine(x.Name);
            }
            Console.ReadLine();

           //  Här använder vi ||-operatorn i Where-Clausen.
            var query2 = context.Tests.Where(c => (c.Id != 0) || (c.UserId == 3));

            foreach (var x in query2)
            {
                Console.WriteLine(x.Name);
            }
            Console.ReadLine();





            var query3 = context.Tests.Where(c => c.UserId == 3);

            foreach (var x in query3)
            {
                Console.WriteLine(x.Name);
            }
            Console.ReadLine();
        }

        public static void LinqExtensionOrdering(StudieContext context)
        {
            // Samtliga test sorterade efter namn först, och sedan sorterade efter UserId.
            var query = context.Tests.OrderBy(c=>c.Name).ThenBy(c=>c.UserId);

            foreach (var x in query)
            {
                Console.WriteLine(x.Name + "  " + x.Id);
            }
            Console.ReadLine();
            Console.WriteLine("-------------------------------------------------");

            // Samma som ovan med nu sorterar vi i sjunkade ordning (Descending) istället!
            var query2 = context.Tests.OrderByDescending(c => c.Name).ThenByDescending(c => c.UserId);

            foreach (var x in query2)
            {
                Console.WriteLine(x.Name + "  " + x.Id);
            }
            Console.ReadLine();

        }

        public static void LinqExtensionProjection (StudieContext context)
        {
            // Projection med Anonymous Object
            var query = context.Tests
                .Where(c => c.UserId == 2).Select(c=> new { Provnamn = c.Name});
            foreach (var x in query)
            {
                Console.WriteLine(x.Provnamn);
            }
            Console.ReadLine();

            // List of Lists
            var questions = context.Tests
            .Select(c => c.Question);

            foreach(var c in questions)
            {
                Console.WriteLine("---");
                foreach(var question in c)
                {
                    Console.WriteLine(question.Query);
                }
            }
            Console.ReadLine();

            // Flatting in with SelectMany-statement
            var questions2 = context.Tests
            .SelectMany(c => c.Question);

            foreach (var question in questions2)
            {
                Console.WriteLine(question.Query);
            }

            Console.ReadLine();

        }

        public static void LinqExtensionDistinct(StudieContext context)
        {
            // Använder Distinct-metoden för att endast välja ut unika UserId och undvika dubletter
            var query = context.Tests
                .Select(c => new { UserId = c.UserId })
                .Distinct();

            foreach (var x in query)
            {
                Console.WriteLine(x.UserId);
            }
            Console.ReadLine();
           

        }

        public static void LinqExtensionGrouping(StudieContext context)
        {
            // Grupperar alla frågor utefter vilket test de tillhör.
            // TestId är min nyckel/key och den kriterie utifrån jag delar in grupperna.
            var testGroups = context.Questions.GroupBy(c => c.TestId);

            foreach (var group in testGroups)
            {
                Console.WriteLine("Key:" + group.Key);

                foreach (var question in group)
                {
                    Console.WriteLine("\t" + question.Query);
                }
            }
            Console.ReadLine();
        }

        public static void LinqExtensionJoining(StudieContext context)
        {
            // Vi förutsätter att vi inte har någon Navigation Property för Test i klassen User och gör därför en INNER JOIN.

            var query = context.Tests.Join(context.Users,
                 c => c.UserId,
                 a => a.Id,
                 (test, user) => new
                 {
                     Provnamn = test.Name,
                     Användare = user.Epost
                 });

            foreach (var x in query)
            {
                Console.WriteLine("Användare: {0} har skapat detta prov: {1}.", x.Användare, x.Provnamn);
            }
            Console.WriteLine("-------------------------------------------------------------------------");
            Console.ReadLine();

            // Vi kör en Group Join för att få exakt samma resultat som när vi Group joinade med LINQ Syntax. Det innebär att vi vill ha följande resultat:
            // Vi vill räkna antalet frågor för varje test med hjälp av en Group Join.

            var query1 = context.Tests.
                 GroupJoin(context.Questions,
                 a => a.Id,
                 c => c.TestId,
                 (test, questions) => new
                 {
                     Testnamn = test.Name,
                     AntalFrågor = questions.Count()
                 });

            foreach (var x in query1.OrderByDescending(x => x.AntalFrågor))
            {
                Console.WriteLine("{0} ({1})", x.Testnamn, x.AntalFrågor);

            }
            Console.ReadLine();

            // Cross Join mellan Test och User

            var query2 = context.Users.
                SelectMany(a => context.Tests,
                (user, test) => new
                {
                    Användarnamn = user.Epost,
                    Provnamn = test.Name
                });

            foreach (var x in query2)
            {
                Console.WriteLine(x.Användarnamn + " " + x.Provnamn);
            }
            Console.ReadLine();

        }






    }
}
