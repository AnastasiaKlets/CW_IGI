﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTO
{
    public class DTOUser
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        public string Role { get; set; }

        public string Mail { get; set; }

        public int Age { get; set; }

        public string FullName { get; set; }
    }
}