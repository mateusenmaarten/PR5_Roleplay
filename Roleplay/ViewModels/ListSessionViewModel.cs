using Microsoft.AspNetCore.Mvc.Rendering;
using PR5_Roleplay.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Roleplay.ViewModels
{
    public class ListSessionViewModel
    {
        public Session Session { get; set; }
        public List<Session> Sessions { get; set; }

        public List<Player> Players { get; set; }
        public List<AdventurePlayer> AdventurePlayers { get; set; }

        public List<string> GetPlayerNames(Session session)
        {
            List<int> playerIDs = new List<int>();
            foreach (var player in session.SessionPlayers)
            {
                playerIDs.Add(player.PlayerID);
            }
            List<string> names = new List<string>();
            foreach (var id in playerIDs)
            {
                foreach (Player player in Players)
                {
                    if (player.PlayerID == id)
                    {
                        names.Add(player.Name);
                    }
                }
            }
            return names;
        }

        //public List<string> GetPlayerCharacterNames(Session session)
        //{
        //    List<int> playerIDs = new List<int>();
        //    foreach (var player in session.SessionPlayers)
        //    {
        //        playerIDs.Add(player.PlayerID);
        //    }
        //    List<string> characternames = new List<string>();
        //    foreach (var id in playerIDs)
        //    {
        //        foreach (Player advPlayer in AdventurePlayers)
        //        {
        //            if (advPlayer.PlayerID == id)
        //            {
        //                characternames.Add(player.Name);
        //            }
        //        }
        //    }
        //    return characternames;
        //}
        

    }
}
