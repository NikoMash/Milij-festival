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

        public bool ErTaget { get; set; }

      

        //constructer
    }
}
