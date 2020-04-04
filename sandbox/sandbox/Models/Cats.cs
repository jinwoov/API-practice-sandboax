using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sandbox.Models
{
    public class Cats
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Type { get; set; }
        public string Gender { get; set; }

        // if not join table use list
        // nav
        public List<Animals> Animal { get; set; }
    }
}
