using System;
namespace Milijøfestival.Shared
{
    public class Bruger
    {
        //properties
        public int BrugerId { get; set; }

        public string Navn { get; set; }

        public char TelefonNr { get; set; }

        public string Email { get; set; }

        public int Alder { get; set; }


        //constructor
        public Bruger(int brugerid, string navn, char telefonnr, string email, int alder)
        {
            BrugerId = brugerid;    
            Navn = navn;    
            TelefonNr = telefonnr;
            Email = email;
            Alder = alder;
        }
    }
}
