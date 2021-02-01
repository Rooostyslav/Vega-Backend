using System.Collections.Generic;
using Vega.BLL.DTO;

namespace Vega.BLL.Interfaces
{
	public interface IContactService
	{
		void Insert(ContactDTO contactDTO);
		void Update(ContactDTO contactDTO);
		void Delete(int id);
		ContactDTO GetContact(int id);
		IEnumerable<ContactDTO> GetContacts();
	}
}
