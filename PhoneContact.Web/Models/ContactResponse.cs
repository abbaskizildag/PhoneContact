using PhoneContact.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneContact.Web.Models
{
    public class ContactResponse
    {
        public List<ContactDto> data { get; set; }
        public object errors { get; set; }
    }
}
