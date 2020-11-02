using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PR5_Roleplay.Models
{
    public class SessionPlayer
    {
        public int SessionPlayerID { get; set; }
        public int PlayerID { get; set; }
        public int SessionID { get; set; }

        //navigation prop
        public Player Player { get; set; }
        public Session Session { get; set; }
    }
}
