using System;

namespace Milijøfestival.Shared
{
    public class Koordinator : Bruger
    {
        //properties 

        public Koordinator(int brugerid, string navn, char telefonnr, string email, int alder) : base (brugerid, navn, telefonnr, email, alder)
        {
        }
    }
}
