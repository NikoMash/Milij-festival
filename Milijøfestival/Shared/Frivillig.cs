using System;
namespace Milijøfestival.Shared
{
    public class Frivillig : Bruger
    {
        //properties
        
        public string Kompetence { get; set; }
        


        //constructer
        public Frivillig(int brugerid, string navn, char telefonnr, string email, DateTime fødselsdato, string kompetence, int rolleid) : base (brugerid, navn, telefonnr, email, fødselsdato, rolleid)
        { 

            Kompetence = kompetence;
        }
    }
}





