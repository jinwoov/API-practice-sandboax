using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sandbox.Models
{
    public class Shelter
    {
        public int DogsID { get; set; }

        public int CatsID { get; set; }

        public Type type { get; set; }

        public Cats Cats { get; set; }

        public Dogs Dogs { get; set; }
    }

    public enum Type
    {
        SmallPlace = 0,
        MediumPlace,
        Suite
    }
}
