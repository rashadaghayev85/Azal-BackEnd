using AutoMapper;
using Domain.Models;
using Repository.Repositories.Interfaces;
using Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
	public class ContactService : IContactService
	{
		private readonly IContactRepository _contactRepo;

		private readonly IMapper _mapper;


		public ContactService(IMapper mapper,
						   IContactRepository contactRepo)

		{
			_contactRepo = contactRepo;
			_mapper = mapper;

		}
		public async Task CreateAsync(Contact contact)
		{
		await _contactRepo.CreateAsync(contact);
		}

		public async Task DeleteAsync(Contact contact)
		{
			 await _contactRepo.DeleteAsync(contact);
		}

		public async Task<IEnumerable<Contact>> GetAllAsync()
		{
			return await _contactRepo.GetAllAsync();
		}

		public  Task<Contact> GetByIdAsync(int id)
		{
			return _contactRepo.GetByIdAsync(id);
		}
	}
}
