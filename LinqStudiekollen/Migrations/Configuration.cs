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
            //        Name = "Smärta",
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
            //        Name = "FågelVetenskap",
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

            //        Query= "Vad heter Tysklands huvudstad?",
            //        Answer = "Berlin.",
            //        Result = "Rätt!",
            //        TestId = 7

            //    },
            //    new Question
            //    {
            //        Query= "Är en häst också en Zebra?",
            //        Answer = "Ja, det är samma djur.",
            //        Result = "Fel!",
            //        TestId = 5
            //    },
            //    new Question
            //    {
            //        Query= "Vad är en kanot?",
            //        Answer = "Ett slags fartyg.",
            //        Result = "Fel!",
            //        TestId = 5
            //    },
            //    new Question
            //    {
            //        Query= " Vill du ha en telefon?",
            //        Answer = "Hels inte",
            //        Result = "Fel!",
            //        TestId = 8
            //    },
            //    new Question
            //    {
            //        Query= "Vad är en fisk?",
            //        Answer = "Ett däggjur.",
            //          Result = "Rätt",
            //        TestId = 3
            //    }



            //    };

            //foreach (var question in questions)
            //    context.Questions.AddOrUpdate(a => a.Query, question);
            #endregion


        }
    }
}
