using Roleplay.Areas.Identity.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PR5_Roleplay.Models
{
    public class Player
    {
        public int PlayerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Country { get; set; }
        public Boolean IsGameMaster { get; set; }

        //navigation prop
        public ICollection<Character> Characters { get; set; }
        public ICollection<AdventurePlayer> AdventurePlayers { get; set; }
        public ICollection<SessionPlayer> SessionPlayers { get; set; }

        //[ForeignKey("CustomUser")]
        public string UserID { get; set; }
        public CustomUser CustomUser { get; set; }
    }
}
