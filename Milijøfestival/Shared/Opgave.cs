using System;
namespace Milijøfestival.Shared
{
    public class Opgave
    {
        //properties
        public int OpgId { get; set; }

        public string OpgBeskrivelse { get; set; }

        


        //constructor
        public Opgave(int opgid, string opgbeskrivelse)
        {
            OpgId = opgid;
            OpgBeskrivelse = opgbeskrivelse;
           
        }
    }
}
