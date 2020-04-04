using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sandbox.Models
{
    public class Animals
    {
        public int DogsID { get; set; }
        public int CatsID { get; set; }

        //nav
        public Cats Cat { get; set; }
        public Dogs Dog { get; set; }
    }
}
