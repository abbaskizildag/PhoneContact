using PhoneContact.Api.Models;
using PhoneContact.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneContact.Api.Services
{
    public interface IContactService
    {
        Task<Response<List<ContactDto>>> GetAllAsync();
        Task<Response<ContactDto>> CreateAsync(ContactDto contact);
        Task<Response<ContactDto>> GetByIdAsync(string id);
    }
}
