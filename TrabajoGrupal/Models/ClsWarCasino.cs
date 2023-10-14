using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrabajoGrupal.Models
{
    public class ClsWarCasino
    {
        public List<int> PlayerCards { get; set; } = new List<int>();
        public List<int> DealerCards { get; set; } = new List<int>();
        public int PlayerScore { get; set; }
        public int DealerScore { get; set; }
        public string Result { get; set; }
        public bool IsWar { get; set; }
        public List<int> WarCards { get; set; } = new List<int>();
    }
}