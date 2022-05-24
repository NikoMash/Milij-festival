using System;
namespace Milijøfestival.Shared
{
    public class TagetVagterView
    {
        //properties
        public string Sted { get; set; }

        public string OpgBeskrivelse { get; set; }

        public string Afdeling { get; set; }

        public DateTime StartTid { get; set; }

        public DateTime SlutTid { get; set; }

        public bool Ertaget { get; set; }




        //constructor
        public TagetVagterView(string sted, string opgbeskrivelse, string afdeling, DateTime starttid, DateTime sluttid, bool ertaget)
        {
            Sted = sted;
            OpgBeskrivelse = opgbeskrivelse;
            Afdeling = afdeling;
            StartTid = starttid;
            SlutTid = sluttid;
            Ertaget = ertaget;

        }
    }
}
