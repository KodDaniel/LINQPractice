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

        public static void LinqExtensionFirstAndLastOperator(StudieContext context)
        {


            //// First-operatorn

            // First-operatorn utgår per default från den första propertyn, i det här fallet UserId. Se nästa kodexempel för hur du gör om du vill sortera utefter en annan property.
            var firstUser = context.Users.First();
            Console.WriteLine("Ge mig den första Usern i User-tabellen:");
            Console.WriteLine(firstUser.Epost);
            Console.WriteLine("-------------------------------------------------------------------------");
            Console.ReadLine();

            Console.WriteLine("Ge mig den första Usern i User-tabellen men sortera efter Epost istället för UserId(default-värdet):");
            var firstUserButByEpost = context.Users.OrderBy(c => c.Epost).First();
            Console.WriteLine(firstUserButByEpost.Epost);
            Console.WriteLine("-------------------------------------------------------------------------");
            Console.ReadLine();

            //FirstOrDefault: With the "First-method", if the User-table is empty, you are going to get an exception when you call the FirstMethod. 
            //  So we can use the "FirstOrDefault-method" and instead I am goinig to get NULL back.
            var firstorDefault = context.Users.OrderBy(c => c.Epost).FirstOrDefault();
            Console.WriteLine("Ge mig den första Usern i User-tabellen men sortera efter Epost istället för UserId(default-värdet). Om ingen resultat finns - returnera NULL:");
            Console.WriteLine(firstUserButByEpost.Epost);
            Console.WriteLine("-------------------------------------------------------------------------");
            Console.ReadLine();

            // Vi kan också placera conditions (predicate) isåväl First-operatorn som FirstOrDefault-operatorn.
            var firstorDefaultWithCondition = context.Users.FirstOrDefault(c=>c.Id >2);
            Console.WriteLine("Ge mig den första Usern som har ett UserId som överstiger 2. Om det inte finns någon sån User returnera NULL:");
            Console.WriteLine(firstorDefaultWithCondition.Epost);
            Console.WriteLine("-------------------------------------------------------------------------");
            Console.ReadLine();

            //// Last-Operator
            //var lastUser = context.Users.Last();
            //Console.WriteLine("Ge mig den sista Usern i User-tabellen:");
            //Console.WriteLine(lastUser.Epost);
            //Console.WriteLine("-------------------------------------------------------------------------");
            //Console.ReadLine();

            // Ersättningskod för Last-operatorn när nyckeln är ORDERBYDescending
            var lastUserReplaceCode = context.Users.OrderByDescending(c=>c.Id).First();
            Console.WriteLine("Ge mig den sista Usern i User-tabellen:");
            Console.WriteLine(lastUserReplaceCode.Epost);
            Console.WriteLine("-------------------------------------------------------------------------");
            Console.ReadLine();



        }

        public static void LinqExtensionSingleAndAllOperator(StudieContext context)
        {
            //// "Single" Returns the only element of a sequence, and throws an exception if there is not exactly one element in the sequence.
            //var testWithId3 = context.Tests.Single(c => c.UserId == 1);
            //Console.WriteLine(testWithId3.Name);
            //Console.ReadLine();

            ////"SingleOrDefault Returns the only element of a sequence, or a default value if the sequence is empty;...
            //// this method throws an exception if there is more than one element in the sequence.            
            //var testWithId3Default = context.Tests.SingleOrDefault(c => c.Id == 23);
            //Console.WriteLine(testWithId3Default.Name);
            //Console.ReadLine();

            //All Operator
            // The All-operator can be used to check if ALL objects match a specified condition/critera
            // Returns a Booleen
            
            // Undersöker fölhande: Har ALLA TEST ett TestId som ej överstiger 2?
            var all = context.Tests.All(c => c.Id > 2);
            Console.WriteLine("Har ALLA TEST ett TestId högre än 2? {0}.", all);
            Console.ReadLine();

            // Undersöker om det finns NÅGOT TEST som har ett högre TestId än 2.
            // Returns a Boolean.
            var any= context.Tests.Any(c => c.Id > 2);
            Console.WriteLine("Har NÅGOT TEST ett TestId högre än 2? {0}.", any);
            Console.ReadLine();


        }

        public static void LinqExtensionAggregating(StudieContext context)
        {
            // Räkna antalet frågor i databasen där resultatet (result-kolumnen) ej är null.
            var countNotNullQuestions = context.Questions.Count(c=>c.Result !=null);
            Console.WriteLine("Det totala antalet frågor i databasen som ej har NULL i resultat-kolumnen är: {0}.", countNotNullQuestions);
            Console.ReadLine();

            // Max, Min, Average
            var max = context.Questions.Max(c => c.TestId);
            var min = context.Questions.Min(c => c.TestId);
            var average =context.Questions.Average(c => c.TestId);

            Console.WriteLine("Det högsta TestId som existerar i Question-tabellen är {0}.",max);
            Console.WriteLine("Det minsta TestId som existerar i Question-tabellen är {0}.", min);
            Console.WriteLine("Medelvärdet för alla TestID:n i Question-tabellen är {0}.", average);
            Console.ReadLine();



        }


        public static void LinqExtensionMethodPartitioning(StudieContext context)
        {
            //Partitioning
            var tests = context.Tests.Skip(10).Take(10);

        }



    }
}
