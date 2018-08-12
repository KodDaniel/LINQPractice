using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqStudiekollen
{
    class DeferredExecution
    {

        public static void DeferredMethod(StudieContext context)
        {
            // OBS EJ KLART. Bara vanliga banala queries nedan SO FAR.
            var users = context.Users;
            var filtered = context.Users.Where(c => c.Id > 3);
            var sorted = context.Users.OrderByDescending(c => c.Id);

            foreach (var user in users)
            {
                Console.WriteLine(user.Epost);
            }
            Console.ReadLine();
        }


    }
}
