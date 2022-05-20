using System;
namespace Milijøfestival.Shared
{
    public class Vagt
    {
        //properties
        public int VagtId { get; set; }

        public DateTime Tid { get; set; }

        public string Sted { get; set; }

        public int OpgId { get; set; }


        //constructer
        public Vagt(int vagtid, DateTime tid, string sted, int opgid)
        {
            VagtId = vagtid;
            Tid = tid;
            Sted = sted;
            OpgId = opgid;
        }
    }
}
