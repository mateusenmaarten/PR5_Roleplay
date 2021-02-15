using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PR5_Roleplay.Models
{
    public class Session
    {
        public int SessionID { get; set; }
        public int PlayerID { get; set; }
        public int AdventureID { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        
        public string Recap { get; set; }
        public Boolean IsPlayed { get; set; }
        public int Duration { get; set; }

        public string SessionGamemaster { get; set; }

        //navigation prop
        public List<SessionPlayer> SessionPlayers { get; set; }
        public Adventure Adventure { get; set; }
    }
}
