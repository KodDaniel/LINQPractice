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

        }

    }
}
