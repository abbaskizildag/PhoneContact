using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PhoneContact.Api.Models;
using PhoneContact.Api.Services;
using PhoneContact.Shared.ControllerBases;
using PhoneContact.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneContact.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : CustomBaseController
    {
        private readonly IContactService _contactService;

        public ContactsController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _contactService.GetAllAsync();
            return CreateActionResultInstance(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var response = await _contactService.GetByIdAsync(id);
            return CreateActionResultInstance(response); //bu kod basecontroller oluşturduk oradan geliyor.
        }

        [HttpPost]
        public async Task<IActionResult> Create(ContactDto contact)
        {
            var response = await _contactService.CreateAsync(contact);
            return CreateActionResultInstance(response);
        }
    }
}
