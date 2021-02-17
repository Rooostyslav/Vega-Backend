using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
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

		public async Task<IEnumerable<ViewContactDTO>> GetContactsAsync()
		{
			var contacts = await unitOfWork.Contacts.GetAllAsync();
			return mapper.Map<IEnumerable<ViewContactDTO>>(contacts);
		}

		public async Task<ViewContactDTO> GetContactAsync(int id)
		{
			var contact = await unitOfWork.Contacts.GetAsync(id);
			return mapper.Map<ViewContactDTO>(contact);
		}

		public async Task CreateAsync(ContactDTO contactDTO)
		{
			var contact = mapper.Map<Contact>(contactDTO);
			await unitOfWork.Contacts.CreateAsync(contact);
		}

		public async Task UpdateAsync(int id, ContactDTO contactDTO)
		{
			var contact = mapper.Map<Contact>(contactDTO);
			contact.Id = id;
			await unitOfWork.Contacts.UpdateAsync(contact);
		}

		public async Task DeleteAsync(int id)
		{
			await unitOfWork.Contacts.DeleteAsync(id);
		}
	}
}
