
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PR5_Roleplay.Models
{
   
    public class Character
    {
        public int CharacterID { get; set; }
        public int PlayerID { get; set; }
        public int CharacterClassID { get; set; }
       
        public string CharacterName { get; set; }
        public string CharacterGender { get; set; }
        public string CharacterDescription { get; set; }
        public int CharacterAge { get; set; }
        public string FavouriteWeapon { get; set; }
        public string HomeTown { get; set; }

        //Navigation prop
        public Player Player { get; set; }
        public CharacterClass CharacterClass { get; set; }
    }
}
