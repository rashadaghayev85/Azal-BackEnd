using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
	public class ContactRepository : BaseRepository<Contact>, IContactRepository
	{
		public ContactRepository(AppDbContext context) : base(context)
		{

		}
	

		public async Task CreateAsync(Contact contact)
		{
			await _context.AddAsync(contact);
			await _context.SaveChangesAsync();
		}

		public async Task DeleteAsync(Contact contact)
		{
			_context.Remove(contact);
			await _context.SaveChangesAsync();
		}

		public async Task<IEnumerable<Contact>> GetAllAsync()
		{
			return await _context.Contacts.ToListAsync();
		}

		public async Task<Contact> GetByIdAsync(int id)
		{
			return await _context.Contacts.FirstOrDefaultAsync(c => c.Id == id);
		}
	}
}
