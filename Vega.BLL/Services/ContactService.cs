using AutoMapper;
using System.Collections.Generic;
using Vega.BLL.DTO;
using Vega.BLL.DTO.ContactModels;
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

		public ViewContactDTO GetContact(int id)
		{
			var contact = unitOfWork.Contacts.Get(id);
			return mapper.Map<ViewContactDTO>(contact);
		}

		public IEnumerable<ViewContactDTO> GetContacts()
		{
			var contacts = unitOfWork.Contacts.GetAll();
			return mapper.Map<IEnumerable<ViewContactDTO>>(contacts);
		}

		public void Insert(ContactDTO contactDTO)
		{
			var contact = mapper.Map<Contact>(contactDTO);
			unitOfWork.Contacts.Insert(contact);
			unitOfWork.Save();
		}

		public void Update(ContactDTO contactDTO)
		{
			var contact = mapper.Map<Contact>(contactDTO);
			unitOfWork.Contacts.Update(contact);
			unitOfWork.Save();
		}
	}
}
