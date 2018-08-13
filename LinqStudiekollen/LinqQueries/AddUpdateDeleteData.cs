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
    }
}
