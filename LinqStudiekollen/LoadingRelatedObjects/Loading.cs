using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqStudiekollen
{
    class Loading
    {

        public static void LazyLoadingMethod(StudieContext context)
        {
            // Denna kod kommer ej kunna köras då jag har disablad LAZY Loading i min konstruktor
            var users = context.Users.Single(c => c.Id == 1);

            foreach (var test in users.Test)
            {
                Console.WriteLine(test.Name);
            }
            Console.ReadLine();
        }

        public static void NPlus1Problem(StudieContext context)
        {
            var tests = context.Tests.ToList();

            foreach (var test in tests)
            {
                Console.WriteLine(test.Name + " " + test.User.Epost);
            }
            Console.ReadLine();
        }

        private static void EagerLoading (StudieContext context)
        {

        }
    }
}
