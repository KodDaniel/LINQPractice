using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqStudiekollen
{
    class LazyLoading
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
    }
}
