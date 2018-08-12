using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqStudiekollen
{
    class IQueryable
    {

        public static void IQueryableMethod(StudieContext context)
        {
            // Query där vi - eftersom vi använder IEnumerable - exekveras omedelbart mot databasen och först efter det applicerar vårt villkor (Where-clause).
            IEnumerable<User> users = context.Users;
            var filtered = users.Where(c => c.Id > 4);

            foreach (var user in filtered)
            {
                Console.WriteLine(user.Epost);
            }
            Console.ReadLine();


            // Samma med IQueryable: Här exekverar vi inte Queryn direkt utan väntar in vårt villkor (Where-clause).
            IQueryable<User> users1 = context.Users;
            var filtered1 = users.Where(c => c.Id > 4);

            foreach (var user in filtered1)
            {
                Console.WriteLine(user.Epost);
            }
            Console.ReadLine();
        }


    }
}
