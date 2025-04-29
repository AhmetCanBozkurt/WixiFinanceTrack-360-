using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wixi.financeApp.Entities.Dtos
{
    public class RegisterRequestDto
    {
        public string UserName { get; set; } ///eMAİL

        public string FullName { get; set; }

        public string Password { get; set; }

        public string UserType { get; set; }

    }
}
