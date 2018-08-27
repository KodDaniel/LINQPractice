using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqStudiekollen
{
    public class User
    {
        public int Id { get; set; }
        public string Epost { get; set; }

     
        public ICollection<Test> Test { get; set; }
    }
}
