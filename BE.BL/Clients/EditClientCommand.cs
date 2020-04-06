using System;
using System.Collections.Generic;
using System.Text;

namespace BE.BL.Clients
{
    public class EditClientCommand
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
