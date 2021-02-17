using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Vega.BLL.BusinessModels;
using Vega.BLL.DTO.PhotoModels;
using Vega.BLL.Interfaces;

namespace Vega.API.Controllers
{
	[Route("api/vehicles/{vehicleId}/photos")]
	[ApiController]
	public class PhotosController : ControllerBase
	{
		private readonly IPhotoService photoService;
		private readonly IVehicleService vehicleService;
		private readonly IWebHostEnvironment webHostEnvironment;
		private readonly PhotoSettings photoSettings;

		public PhotosController(IPhotoService photoService, IVehicleService vehicleService,
			IOptionsSnapshot<PhotoSettings> optionSnapshot,
			IWebHostEnvironment webHostEnvironment)
		{
			this.photoService = photoService;
			this.vehicleService = vehicleService;
			this.webHostEnvironment = webHostEnvironment;
			this.photoSettings = optionSnapshot.Value;
		}

		[HttpPost]
		public async Task<IActionResult> UploadPhotoAsync(int vehicleId, IFormFile file)
		{
			var vehicle = vehicleService.GetVehicleAsync(vehicleId);
			if (vehicle == null)
			{
				return NotFound();
			}

			if (file == null) return BadRequest("File is null");

			if (file.Length == 0) return BadRequest("Empty file");

			if (file.Length > photoSettings.MaxBytes) return BadRequest("Max file size exceeded");

			if (!photoSettings.IsSupportedFile(file.FileName))
			{
				return BadRequest("Invalid file type");
			}

			if (string.IsNullOrWhiteSpace(webHostEnvironment.WebRootPath))
			{
				webHostEnvironment.WebRootPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
			}

			string uploadsFolderPath = Path.Combine(webHostEnvironment.WebRootPath, "images");
			if (!Directory.Exists(uploadsFolderPath))
			{
				Directory.CreateDirectory(uploadsFolderPath);
			}

			string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
			string filePath = Path.Combine(uploadsFolderPath, fileName);

			using (var stream = new FileStream(filePath, FileMode.Create))
			{
				file.CopyTo(stream);
			}

			var photo = new PhotoDTO
			{
				FileName = fileName,
				VehicleId = vehicle.Id
			};

			await photoService.CreateAsync(photo);

			return Ok();
		}

		[HttpGet]
		public async Task<IActionResult> GetPhotosAsync(int vehicleId)
		{
			var photo = await photoService.GetPhotoAsync(vehicleId);
			if (photo == null)
			{
				return NotFound("Photos not exist");
			}

			string filePath = Path.Combine(webHostEnvironment.WebRootPath, "images", photo.FileName);

			string photoType = "image/" + Path.GetExtension(photo.FileName).Trim('.');

			return PhysicalFile(filePath, photoType, photo.FileName);
		}
	}
}
