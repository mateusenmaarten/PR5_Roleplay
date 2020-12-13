using Microsoft.AspNetCore.Mvc.Rendering;
using PR5_Roleplay.Models;
using Roleplay.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Roleplay.ViewModels
{
    public class CreateCharacterViewModel
    {
        public Character Character { get; set; }

        public SelectList CharacterClasses { get; set; }

        public SelectList Players { get; set; }

    }
}
