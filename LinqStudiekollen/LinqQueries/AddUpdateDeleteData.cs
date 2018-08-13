using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqStudiekollen.LinqQueries
{
    class AddUpdateDeleteData
    {
        public static void AddDataMvcApproach(StudieContext context)
        {

            var test = new Test
            {
                Name = "Djurkunskap A",
                UserId = 1,
            };

            context.Tests.Add(test);
            context.SaveChanges();
        }

        public static void AddDataWpfApproach(StudieContext context)
        {
           // We load our existing users
           var users = context.Users.ToList();

           var user = context.Users.Single(a => a.Id == 1);

            var test = new Test
            {
               Name = "Djurkunskap A",
                User = user
            };

            context.Tests.Add(test);
            context.SaveChanges();
        }

        public static void UpdateData(StudieContext context)
        {
           // Vi hämtar användaren med primärnyckeln "4"...
           //...med hjälp av "Find-metoden" och lagrar resultatet i variabeln "user.
            var user = context.Users.Find(4); // Instead of: Single(c=c.Id == 4).

            // Uppdaterar med nya värdet "Linda@gmail.com
            user.Epost = "Linda@gmail.com";

            context.SaveChanges();

        }

        public static void DeleteDataWithCascade(StudieContext context)
        {

        }

        public static void DeleteDataNotCascade(StudieContext context)
        {

        }

    }
}
