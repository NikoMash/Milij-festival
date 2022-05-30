using System;
namespace Milijøfestival.Shared
{
    public class Bruger
    {
        //properties
        public int BrugerId { get; set; }
        public string Navn { get; set; }
        public string TelefonNr { get; set; }
        public string Email { get; set; }
        public DateTime Fødselsdato { get; set; }
        public int RolleId { get; set; }


        
        //Constructor
        public Bruger(string navn, string telefonnr, string email, DateTime fødselsdato, int rolleid)
        {
            Navn = navn;    
            TelefonNr = telefonnr;
            Email = email;
            Fødselsdato = fødselsdato;
            RolleId = rolleid;
        }

        public Bruger()
        {

        }


    }




}
