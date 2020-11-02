using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PR5_Roleplay.Models
{
    public class AdventurePlayer
    {
        public int AdventurePlayerID { get; set; }
        public int AdventureID { get; set; }
        public int PlayerID { get; set; }
        public Boolean isGameMaster { get; set; }

        //navigation prop
        public Player Player { get; set; }
        public Adventure Adventure { get; set; }
    }
}
