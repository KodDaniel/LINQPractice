using System;
using System.Collections.Generic;
using System.Data.Entity;
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

        public static void EagerLoading (StudieContext context)
        {
            //EagerLoading
            var tests = context.Tests.Include(c => c.User).ToList();

            foreach (var test in tests)
            {
                Console.WriteLine(test.Name + " " + test.User.Epost);
            }
            Console.ReadLine();


            // We use EagerLoad to load the User with userId 2 AND his tests
            var user = context.Users.Include(a => a.Test).Single(a => a.Id == 2);

            // Vi itererar genom testen FÖR DENNA USER och skriver ut de i kommandorutan. 
            foreach (var test in user.Test)
            {
                Console.WriteLine("{0}", test.Name);
            }
            Console.ReadLine();
        }

        public static void ExplicitLoading(StudieContext context)
        {

            var user = context.Users.Single(a => a.Id == 2);

            //MSDN-Way
            context.Entry(user).Collection(a => a.Test).Query().Where(c => c.Name == "Svenska").Load();

            // The Mosh Way
            context.Tests.Where(c => c.UserId == user.Id && c.Name == "Svenska").Load();

            foreach (var test in user.Test)
            {
                Console.WriteLine("{0}", test.Name);
            }
            Console.ReadLine();

            // Vi vill ha alla Users och alla deras test

            var users = context.Users.ToList();
            
            // Returnerar Enumerable med alla UserId
            var userIds = users.Select(a => a.Id);

            context.Tests.Where(c => userIds.Contains(c.UserId) && c.Id > 5).Load();
          
        }

    }
}
