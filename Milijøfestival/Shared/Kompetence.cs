using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milijøfestival.Shared
{
    public class Kompetence
    {
        //properties
        public string Beskrivelse { get; set; }

        //constructor
        public Kompetence(string beskrivelse)
        {
            Beskrivelse = beskrivelse;
        }
    }
}
