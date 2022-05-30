using System;
namespace Milijøfestival.Shared
{
    public class Frivillig : Bruger
    {
        //properties
        
        public string Kompetence { get; set; }
        


        //constructer
        public Frivillig(string navn, string telefonnr, string email, DateTime fødselsdato, string kompetence, int rolleid) : base (navn, telefonnr, email, fødselsdato, rolleid)
        { 

            Kompetence = kompetence;
        }

        public Frivillig()
        {

        }
    }
}





