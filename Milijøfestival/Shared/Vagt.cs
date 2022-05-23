using System;
namespace Milijøfestival.Shared
{
    public class Vagt
    {
        //properties
        
        public DateTime StartTid { get; set; }

        public DateTime SlutTid { get; set; }

        public string? Afdeling { get; set; }

        public string? Sted { get; set; }

        public int OpgId { get; set; }


        //constructer
        public Vagt(DateTime starttid, DateTime sluttid, string sted, int opgid)
        {
            StartTid = starttid;
            SlutTid = sluttid;
            Sted = sted;
            OpgId = opgid;
        }

        public Vagt()
        {

        }
    }
}
