﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BE.BL.Clients.Edit
{
    public class EditClientCommand
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
    }
}
