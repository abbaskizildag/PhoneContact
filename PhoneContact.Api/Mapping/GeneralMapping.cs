using AutoMapper;
using PhoneContact.Api.Models;
using PhoneContact.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneContact.Api.Mapping
{
    public class GeneralMapping:Profile
    {
        public GeneralMapping()
        {
            CreateMap<Contact, ContactDto>().ReverseMap();

        }
    }
}
