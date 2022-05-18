using System;
namespace Milijøfestival.Shared
{
    public class Bruger
    {
        //properties
        public int BrugerId { get; set; }
        public string Navn { get; set; }
        public int TelefonNr { get; set; }
        public string Email { get; set; }
        public int Alder { get; set; }

        //Constructor
        public Bruger(int brugerid, string navn, int telefonnr, string email, int alder)
        {
            BrugerId = brugerid;    
            Navn = navn;    
            TelefonNr = telefonnr;
            Email = email;
            Alder = alder;
        }






    }
}
