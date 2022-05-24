using System;
namespace Milijøfestival.Shared
{
    public class Rolle
    {
        //properties
        public int RolleId { get; set; }

        public string RolleNavn { get; set; }

     


        //constructor
        public Rolle(int rolleid, string rollenavn)
        {
            RolleId = rolleid;
            RolleNavn = rollenavn;
        
        }
    }
}
