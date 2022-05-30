using System;
namespace Milijøfestival.Shared
{
    public class FrivilligOversigtView
    {
        //properties
        public string Navn { get; set; }

        public string TelefonNr { get; set; }

        public string Email { get; set; }

        public DateTime Fødselsdato { get; set; }

        public string RolleNavn { get; set; }





        //constructor
        public FrivilligOversigtView(string navn, string telefonnr, string email, DateTime fødselsdato, string rollenavn)
        {
            Navn = navn;
            TelefonNr = telefonnr;
            Email = email;
            Fødselsdato = fødselsdato;
            RolleNavn = rollenavn;

        }
    }
}
