using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqStudiekollen
{
    public class Question
    {
        public int Id { get; set; }
        public string Query { get; set; }
        public string Answer { get; set; }
        public string Result { get; set; }
        // virtual borrtaget för att undvika Lazy loading
        public Test Test { get; set; }
        public int TestId { get; set; }
    }
}
