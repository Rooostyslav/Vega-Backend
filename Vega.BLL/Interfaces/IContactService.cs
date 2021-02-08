using System.Collections.Generic;
using Vega.BLL.DTO.ContactModels;

namespace Vega.BLL.Interfaces
{
	public interface IContactService
	{
		void Insert(ContactDTO contactDTO);
		void Update(ContactDTO contactDTO);
		void Delete(int id);
		ViewContactDTO GetContact(int id);
		IEnumerable<ViewContactDTO> GetContacts();
	}
}
