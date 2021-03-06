﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqStudiekollen
{
    public class Test
    {
        public int Id { get; set; }
        public string Name { get; set; }
        // Skala bort logiken från DateTime-variablarna och implementera samma med Fluent-API istället
        public DateTime? CreateDate { get; set; }
        public DateTime? ChangeDate { get; set; }
        public  virtual ICollection<Question> Question { get; set; }
        public int UserId { get; set; }
        // virtual borrtaget för att undvika Lazy loading
        public virtual User User { get; set; }
    }
}

