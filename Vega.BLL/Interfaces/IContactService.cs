using System.Collections.Generic;
using System.Threading.Tasks;
using Vega.BLL.DTO.ContactModels;

namespace Vega.BLL.Interfaces
{
	public interface IContactService : ICUDService<ContactDTO>
	{
		Task<IEnumerable<ViewContactDTO>> GetContactsAsync();

		Task<ViewContactDTO> GetContactAsync(int id);
	}
}
