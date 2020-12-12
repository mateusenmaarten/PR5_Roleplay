using Microsoft.AspNetCore.Identity;
using PR5_Roleplay.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Roleplay.Areas.Identity.Data
{
    public class CustomUser : IdentityUser
    {
        [PersonalData]
        public Player player { get; set; }
    }
}
