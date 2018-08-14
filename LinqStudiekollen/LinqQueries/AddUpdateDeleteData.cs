using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net.Mime;
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
            // Obs detta sätt förutsätter att User-Och Test- har ändrats till WillCascadeDelete = False i Dbcontext Fluent-API.
            var user = context.Users.Find(2); 
            context.Users.Remove(user);

            context.SaveChanges();
        }

        public static void DeleteDataNotCascade(StudieContext context)
        {
            //  If we have CascadeDelete OFF we have to explicitly delete tests first and after that the user. 
            
            // Eager Loading User with UserId 8 AND his tests
            var user = context.Users.Include(a => a.Test).Single(a => a.Id == 2);

            // Tar bort de test vi Eager Loadat
            context.Tests.RemoveRange(user.Test);
           
            // Tar bort Usern.
            context.Users.Remove(user);

            context.SaveChanges();


        }

        public static void ChangeTracker(StudieContext context)
        {

        }

    }
}
