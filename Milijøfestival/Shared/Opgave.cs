using System;
namespace Milijøfestival.Shared
{
    public class Opgave
    {
        //properties
        public int OpgId { get; set; }

        public string OpgBeskrivelse { get; set; }

        public int AntalVagter { get; set; }


        //constructor
        public Opgave(int opgid, string opgbeskrivelse, int antalvagter)
        {
            OpgId = opgid;
            OpgBeskrivelse = opgbeskrivelse;
            AntalVagter = antalvagter;
        }
    }
}
