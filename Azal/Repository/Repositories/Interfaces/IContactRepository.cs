using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories.Interfaces
{
	public interface IContactRepository : IBaseRepository<Contact>
	{
		Task<IEnumerable<Contact>> GetAllAsync();
		Task CreateAsync(Contact contact);
		Task<Contact> GetByIdAsync(int id);
		Task DeleteAsync(Contact contact);
		Task EditSaveAsync();

	}
}
