using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.Interfaces
{
	public interface IContactService
	{
		Task<IEnumerable<Contact>> GetAllAsync();
		Task CreateAsync(Contact contact);
		Task<Contact> GetByIdAsync(int id);
		Task DeleteAsync(Contact contact);
	}
}
