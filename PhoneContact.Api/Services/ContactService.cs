using AutoMapper;
using MongoDB.Driver;
using PhoneContact.Api.Models;
using PhoneContact.Api.Settings;
using PhoneContact.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneContact.Api.Services
{
    public class ContactService: IContactService
    {
        private readonly IMongoCollection<Contact> _contactCollection;

        private readonly IMapper _mapper;

        public ContactService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _contactCollection = database.GetCollection<Contact>(databaseSettings.ContactCollectionName);
            _mapper = mapper;
        }

        public async Task<Response<List<ContactDto>>> GetAllAsync()
        {
            var contacts = await _contactCollection.Find(contact => true).ToListAsync();

            return Response<List<ContactDto>>.Success(_mapper.Map<List<ContactDto>>(contacts), 200);
        }

        public async Task<Response<ContactDto>> CreateAsync(ContactDto contactDto)
        {
            var contact = _mapper.Map<Contact>(contactDto);

            await _contactCollection.InsertOneAsync(contact);

            return Response<ContactDto>.Success(_mapper.Map<ContactDto>(contact),200);
        }

        public async Task<Response<ContactDto>> GetByIdAsync(string id)
        {
            var contact = await _contactCollection.Find<Contact>(x => x.Id == id).FirstOrDefaultAsync();
            if (contact == null)
            {
                return Response<ContactDto>.Fail("Contact not found", 404);
            }

            return Response<ContactDto>.Success(_mapper.Map<ContactDto>(contact), 200);
        }
    }
}
