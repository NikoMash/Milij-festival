using System;

namespace Milijøfestival.Shared
{
    public class Koordinator : Bruger
    {
        //properties 

        public Koordinator(int brugerid, string navn, char telefonnr, string email, DateTime fødselsdato, int rolleid) : base (brugerid, navn, telefonnr, email, fødselsdato, rolleid)
        {
        }
    }
}

