using Microsoft.AspNetCore.Mvc.Rendering;
using PR5_Roleplay.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Roleplay.ViewModels
{
    public class EditSessionViewModel
    {
        public Session Session { get; set; }

        public SelectList Adventures { get; set; }

        public IEnumerable<SelectListItem> SessionPlayers { get; set; }
        public IEnumerable<int> SelectedSessionPlayers { get; set; }

    }
}
