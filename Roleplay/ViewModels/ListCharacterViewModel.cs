using Microsoft.AspNetCore.Mvc.Rendering;
using PR5_Roleplay.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Roleplay.ViewModels
{
    public class ListCharacterViewModel
    {
        public string CharacterSearch { get; set; }

        public List<Character> Characters { get; set; }

    }
}
