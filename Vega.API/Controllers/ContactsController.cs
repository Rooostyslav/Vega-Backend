using System.Linq;
using System.Threading.Tasks;
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
		public async Task<IActionResult> GetContactsAsync()
		{
			var contacts = await contactService.GetContactsAsync();

			if (contacts.Count() > 0)
			{
				return Ok(contacts);
			}

			return NoContent();
		}

		[HttpPost]
		public async Task<IActionResult> CreateContactAsync([FromBody] ContactDTO contact)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			await contactService.CreateAsync(contact);

			return Ok(contact);
		}

	}
}
