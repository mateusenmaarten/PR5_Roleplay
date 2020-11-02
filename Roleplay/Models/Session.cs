using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PR5_Roleplay.Models
{
    public class Session
    {
        public int SessionID { get; set; }
        public int AdventureID { get; set; }
        public DateTime Date { get; set; }
        public DateTime Time { get; set; }
        public string Recap { get; set; }
        public Boolean IsPlayed { get; set; }
        public int Duration { get; set; }

        //navigation prop
        public ICollection<SessionPlayer> SessionPlayers { get; set; }
        public Adventure Adventure { get; set; }
    }
}
