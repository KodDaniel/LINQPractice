using System.Collections.Generic;

namespace LinqStudiekollen.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<LinqStudiekollen.StudieContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(LinqStudiekollen.StudieContext context)
        {
            #region AddingUsers
            //var users = new List<User>
            //{
            //    new User
            //    {

            //        Epost = "Ida@home.se"
            //    },
            //    new User
            //    {
            //        Epost = "Niklas@gmail.com"
            //    },
            //    new User
            //    {
            //        Epost = "Oskar@glocalnet.net"
            //    },
            //    new User
            //    {
            //        Epost = "Linda@Hotmail.com"
            //    },
            //    new User
            //    {
            //        Epost = "Nils@home.se"
            //    }


            //};

            //foreach (var user in users)
            //    context.Users.AddOrUpdate(a => a.Epost, user); 
            #endregion

            #region AddingTests
            //var tests = new List<Test>
            //{
            //    new Test
            //    {

            //        Name = "Svenska",
            //        UserId = 1
            //    },
            //    new Test
            //    {
            //        Name = "Engelska",
            //        UserId = 1
            //    },
            //    new Test
            //    {
            //        Name = "Matte",
            //        UserId = 1
            //    },
            //    new Test
            //    {
            //        Name = "Naturvetenskap",
            //        UserId = 2
            //    },
            //    new Test
            //    {
            //        Name = "Kemi",
            //        UserId = 2

            //    },
            //    new Test
            //    {
            //        Name = "Ondska",
            //        UserId = 1

            //    },

            //    new Test
            //    {
            //        Name = "Sm�rta",
            //        UserId = 1

            //    },

            //    new Test
            //    {
            //        Name = "Kemi",
            //        UserId = 4

            //    },
            //    new Test
            //    {
            //        Name = "KostVetenskap",
            //        UserId = 4

            //    },

            //    new Test
            //    {
            //        Name = "F�gelVetenskap",
            //        UserId = 4

            //    },
            //    new Test
            //    {
            //        Name = "OrdVetenskap",
            //        UserId = 3

            //    },
            //    new Test
            //    {
            //        Name = "Atomtvenskap",
            //        UserId = 3

            //    },
            //    new Test
            //    {
            //        Name = "OOP3",
            //        UserId = 5

            //    }
            //}; 


            //foreach (var test in tests)
            //    context.Tests.AddOrUpdate(a => a.Name, test);
            #endregion

            #region AddingQuestions
            //var questions = new List<Question>
            //{
            //    new Question
            //    {

            //        Query= "Hur avbest�ller jag min konseret",
            //        Answer = "Det g�r ej med s� kort varsel.",
            //        TestId = 7

            //    },
            //    new Question
            //    {
            //        Query= "Var svaret funktionellt?",
            //        Answer = "Definiera funktionellt",
            //        TestId = 5
            //    },
            //    new Question
            //    {
            //        Query= "Hur f�r jag ett nytt?",
            //        Answer = "Ett nytt vad�?.",
            //        TestId = 5
            //    },
            //    new Question
            //    {
            //        Query= " Vill du inte ha n�gra mejl?",
            //        Answer = "Nej",
            //        TestId = 8
            //    },
            //    new Question
            //    {
            //        Query= "Uppsala Kommun?",
            //        Answer = "S�d�r.",
            //        TestId = 3
            //    }



            //};

            //foreach (var question in questions)
            //    context.Questions.AddOrUpdate(a => a.Query, question);
            #endregion


        }
    }
}
