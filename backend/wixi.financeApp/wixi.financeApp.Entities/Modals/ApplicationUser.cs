using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace wixi.financeApp.Entities.Modals
{
    public class ApplicationUser : IdentityUser
    {

        public string? FullName { get; set; }
        public string? ProfilePicture { get; set; }
        public DateTime DateofBirth { get; set; }

     


    }

}
