﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneContact.Shared.Dtos
{
    public class ContactDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        public string Description { get; set; }
        public DateTime CreatedTime { get; set; }
        public bool IsActive { get; set; }
    }
}
