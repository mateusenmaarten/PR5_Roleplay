﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PR5_Roleplay.Models
{
    public class Adventure
    {
        public int AdventureID { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public string MainVillain { get; set; }
        public string Genre { get; set; }
        public string Author { get; set; }

        //navigation prop
        public List<AdventurePlayer> AdventurePlayers { get; set; }
        public ICollection<Session> Sessions { get; set; }
    }
}
