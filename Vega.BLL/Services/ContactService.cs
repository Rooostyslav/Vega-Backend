using AutoMapper;
using System.Collections.Generic;
using Vega.BLL.DTO;
using Vega.BLL.Interfaces;
using Vega.DAL.Entity;
using Vega.DAL.Interfaces;

namespace Vega.BLL.Services
{
	public class ContactService : IContactService
	{
		private readonly IUnitOfWork unitOfWork;
		private readonly IMapper mapper;

		public ContactService(IUnitOfWork unitOfWork, IMapper mapper)
		{
			this.unitOfWork = unitOfWork;
			this.mapper = mapper;
		}

		public void Delete(int id)
		{
			unitOfWork.Contacts.Delete(id);
			unitOfWork.Save();
		}

		public ContactDTO GetContact(int id)
		{
			var contact = unitOfWork.Contacts.Get(id);
			return mapper.Map<ContactDTO>(contact);
		}

		public IEnumerable<ContactDTO> GetContacts()
		{
			var contacts = unitOfWork.Contacts.GetAll();
			return mapper.Map<IEnumerable<ContactDTO>>(contacts);
		}

		public void Insert(ContactDTO contactDTO)
		{
			var contact = mapper.Map<Contact>(contactDTO);
			unitOfWork.Contacts.Insert(contact);
		}

		public void Update(ContactDTO contactDTO)
		{
			var contact = mapper.Map<Contact>(contactDTO);
			unitOfWork.Contacts.Update(contact);
		}
	}
}
