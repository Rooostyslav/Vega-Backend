using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Vega.BLL.DTO.ContactModels;
using Vega.BLL.Interfaces;

namespace Vega.API.Controllers
{
	[Route("api/contacts")]
	[ApiController]
	public class ContactsController : ControllerBase
	{
		private readonly IContactService contactService;

		public ContactsController(IContactService contactService)
		{
			this.contactService = contactService;
		}

		[HttpGet]
		public IActionResult GetContacts()
		{
			var contacts = contactService.GetContacts();
			if (contacts.Count() > 0)
			{
				return Ok(contacts);
			}

			return NoContent();
		}

		[HttpPost]
		public IActionResult CreateContact([FromBody] ContactDTO contact)
		{
			contactService.Insert(contact);

			return Ok(contact);
		}

	}
}
