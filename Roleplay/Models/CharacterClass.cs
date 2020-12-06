using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PR5_Roleplay.Models
{
    public class CharacterClass
    {
        public int CharacterClassID { get; set; }
        public string CharacterClassName { get; set; }
        public string CharacterClassDescription { get; set; }
        public string CharacterClassIcon { get; set; }

        //navigation prop
        public ICollection<Character> Characters { get; set; }

        public static implicit operator CharacterClass(SelectList v)
        {
            throw new NotImplementedException();
        }
    }
}
