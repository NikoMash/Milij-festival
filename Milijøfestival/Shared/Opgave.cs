using System;
namespace Milijøfestival.Shared
{
    public class Opgave
    {
        public Opgave()
        {

        }
        //propertes
        public int OpgId { get; set; }

        public string OpgBeskrivelse { get; set; }

        public int AntalVagter { get; set; }


        //constructor
        public Opgave(int opgid, string opgbeskrivelse, int antalvagter)
        {
            OpgId = opgid;
            opgbeskrivelse = opgbeskrivelse;
            AntalVagter = antalvagter;
        }
    }
}
