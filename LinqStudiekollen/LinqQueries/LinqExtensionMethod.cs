using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqStudiekollen.LinqQueries
{
    class LinqExtensionMethod
    {
        public static void LinqContains(StudieContext context)
        {
            var tests = context.Tests.Where(c => c.Name.Contains("Svenska")).OrderBy(c => c.Name);
            foreach (var test in tests)
            {
                Console.WriteLine("Detta prov har namnet Svenska:  {0}.", test.Name);
            }
            Console.ReadLine();

        }

    }
}
