using System;
namespace Milijøfestival.Shared
{
    public class Frivillig : Bruger
    {
        //properties
        public int FrivilligId { get; set; }

        public string Kompetencer { get; set; }


        //constructer
        public Frivillig(int frivilligid, string kompetencer, int brugerid, string navn, int telefonnr, string email, int alder) : base (brugerid, navn, telefonnr, email, alder)
        {
            FrivilligId = frivilligid;
            Kompetencer = kompetencer;
            
        }
    }
}
