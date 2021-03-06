﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IrmsManagement.Api.Dtos
{
    public class UpdateContactDto
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string FullName { get; set; }

        public string PreferredName { get; set; }

        public string Email { get; set; }

        public string MobileNumber { get; set; }
    }
}
