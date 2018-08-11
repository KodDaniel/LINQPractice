using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using LinqStudiekollen.Migrations;

namespace LinqStudiekollen
{
    class LinqSyntax
    {
        public static void LinqRestriction(StudieContext context)
        {
            // Väljer ut alla test med UserId 4 och sorterar efter Name.
            var query =
                from c in context.Tests
                where c.UserId == 4
                orderby c.Name
                select c;

            Console.WriteLine("Dessa prov har UserId4: ");
            foreach (var test in query)
            {
                Console.WriteLine("Testnamn: {0}.", test.Name);
            }
            Console.WriteLine("--------------------------------------------------------------------------------");
            Console.ReadLine();

            // Väljer ut alla questions med TestId 3 ELLER alla questions som har svaret "nej". 
            var queryMultipleConditions =
                from a in context.Questions
                where a.TestId == 3 || a.Answer == "nej"
                select a;
               Console.WriteLine("Dessa frågor har antingen TestId 3 ELLER svaret 'nej':");
            foreach (var question in queryMultipleConditions)
            {
                Console.WriteLine("Fråga: {0}.",question.Query);
            }
            Console.WriteLine("--------------------------------------------------------------------------------");
            Console.ReadLine();

            var queryMultipleConditions2 =
                from a in context.Tests
                where a.Id == 2 && a.UserId == 1
                select a;
            Console.WriteLine("Dessa test har TestId 2 OCH UserId 1:");
            foreach (var tests in queryMultipleConditions2)
            {
                Console.WriteLine("Testnamn: {0}.", tests.Name);
            }
            Console.ReadLine();
        }

        public static void LinqOrdering(StudieContext context)
        {
            var allTestsByDescendingTestId =
                from k in context.Tests
                where k.Id != 0
                orderby k.Id descending
                select k;
            Console.WriteLine("Alla test som har giltiga TestId (ej 0) sorterade efter TestId i sjunkande ordning:");
            foreach (var tests in allTestsByDescendingTestId)
            {
                
                Console.WriteLine("Testnamn: {0}. TestId: {1}.",tests.Name,tests.Id);
            }
            Console.WriteLine("--------------------------------------------------------------------------------");
            Console.ReadLine();

            var allUsersSortedByUserIdDescendingAndThenSortedByEpost =
                from u in context.Users
                where u.Id != 0
                orderby u.Id descending, u.Epost
                select u;

            Console.WriteLine("Alla användare sorterade efter UserId i sjunkande ordning och sedan sorterade efter Epost (efter Defaultvärde som är stigande):");
            foreach (var user in allUsersSortedByUserIdDescendingAndThenSortedByEpost)
            {
                Console.WriteLine("Epost:{0}. UserId: {1}.", user.Epost,user.Id);
            }
            Console.ReadLine();
        }

        public static void LinqProjection(StudieContext context)
        {
            // Använder Projection för att välja ut "Query"- och "Answer"-kolumnerna från tabellen "Question".
            var query =
                from c in context.Questions
                select new {Fråga = c.Query, Svar= c.Answer};

            foreach (var question in query)
            {
                Console.WriteLine("Fråga: {0} Svar: {1}",question.Fråga,question.Svar);
            }
            Console.ReadLine();

        }

        public static void LinqGrouping(StudieContext context)
        {
            // Grupperar test efter deras UserId (tilldelar alltså i praktiken rätt användare rätt test).
            var query =
                from t in context.Tests
                group t by t.UserId
                into g
                select g;

            foreach (var group in query)
            {
                // Key är UserId i detta fall
                Console.WriteLine(group.Key);

                foreach (var test in group)
                {
                    Console.WriteLine("\t{0}",test.Name);
                }

            }
            Console.WriteLine("-----------------------------------------------------------------------------------------------");
            Console.ReadLine();

            // Med hjälp av Count-metoden räknar jag ut HUR MÅNGA prov varje användare har.
            var query1 =
                from t in context.Tests
                group t by t.UserId
                into g
                select g;

            foreach (var group in query)
            {
                // Första argumentet (Key) kommer vara UserId. Det andra argumentet är antalet kurs INOM detta userId (denna användare).
                Console.WriteLine("{0} ({1})",group.Key,group.Count());
            }
            Console.ReadLine();
        }

        public static void LinqJoining(StudieContext context)
        {
            // Vi vill visa en lista med alla användare (Epost) och tillhörande prov för respektive användare.
            //NOTERA att detta är er indirekt join. LINQ Provider gör joinen ÅT MIG vid run time med hjälp av navigation properties. Jag behöver alltså inte skriva den själv.
            var query =
                from c in context.Tests
                select new { Användare = c.User.Epost, Testnamn = c.Name };

            foreach (var userTest in query)
            {
                Console.WriteLine("Användare: {0}. Prov {1}.", userTest.Användare, userTest.Testnamn);
            }
            Console.ReadLine();
            Console.WriteLine("-----------------------------------------------------------------------------------------------");

            
            var query2 =
                from c in context.Tests
                join a in context.Users on c.UserId equals a.Id
                select new { Användare = a.Epost, Testnamn = c.Name };

            foreach (var userTest in query2)
            {
                Console.WriteLine("Användare: {0}. Prov {1}.", userTest.Användare, userTest.Testnamn);
            }
            Console.ReadLine();
            Console.WriteLine("-----------------------------------------------------------------------------------------------");

            // Nedan vill räkna antalet frågor för varje test med hjälp av en Group Join.

            var query3 =
                from a in context.Tests
                join c in context.Questions on a.Id equals c.TestId into g
                select new { Testnamn = a.Name, Frågor = g.Count() };

            foreach (var x in query3)
            {
                Console.WriteLine("{0} ({1})", x.Testnamn, x.Frågor);
            }
            Console.ReadLine();
            Console.WriteLine("-----------------------------------------------------------------------------------------------");

            // Kross Joinar alla Users med alla Tests

            var query4 =
                from a in context.Users
                from c in context.Tests
                select new {Användare = a.Epost, Prov = c.Name};

            foreach (var x in query4)
            {
                Console.WriteLine("{0} - {1}",x.Användare,x.Prov);
            }
            Console.ReadLine();

        }











    }
}
