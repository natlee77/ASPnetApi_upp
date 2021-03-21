using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryProject.Models
{
    public class RegisterVM
    {
        //   registrera user  info
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password  { get; set; }
    }
}
