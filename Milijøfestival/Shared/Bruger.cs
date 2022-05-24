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
        public DateTime Fødselsdato { get; set; }
        public int RolleId { get; set; }



        //Constructor
        public Bruger(int brugerid, string navn, char telefonnr, string email, DateTime fødselsdato, int rolleid)
        {
            BrugerId = brugerid; 
            Navn = navn;    
            TelefonNr = telefonnr;
            Email = email;
            Fødselsdato = fødselsdato;
            RolleId = rolleid;
        }






    }
}
