using System;

namespace Milijøfestival.Shared
{
    public class Koordinator : Bruger
    {
        //properties 

        public Koordinator(string navn, char telefonnr, string email, DateTime fødselsdato, int rolleid) : base (navn, telefonnr, email, fødselsdato, rolleid)
        {
        }
    }
}

