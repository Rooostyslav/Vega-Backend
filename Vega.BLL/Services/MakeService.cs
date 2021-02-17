using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using Vega.BLL.DTO;
using Vega.BLL.Interfaces;
using Vega.DAL.Entity;
using Vega.DAL.Interfaces;

namespace Vega.BLL.Services
{
	public class MakeService : IMakeService
	{
		private readonly IUnitOfWork unitOfWork;
		private readonly IMapper mapper;

		public MakeService(IUnitOfWork unitOfWork, IMapper mapper)
		{
			this.unitOfWork = unitOfWork;
			this.mapper = mapper;
		}

		public async Task<IEnumerable<MakeDTO>> GetMakesAsync()
		{
			var makes = await unitOfWork.Makes.GetAllAsync();
			return mapper.Map<IEnumerable<MakeDTO>>(makes);
		}

		public async Task<MakeDTO> GetMakeAsync(int id)
		{
			var make = await unitOfWork.Makes.GetAsync(id);
			return mapper.Map<MakeDTO>(make);
		}

		public async Task CreateAsync(MakeDTO makekDTO)
		{
			var make = mapper.Map<Make>(makekDTO);
			await unitOfWork.Makes.CreateAsync(make);
		}

		public async Task UpdateAsync(int id, MakeDTO makekDTO)
		{
			var make = mapper.Map<Make>(makekDTO);
			make.Id = id;
			await unitOfWork.Makes.UpdateAsync(make);
		}

		public async Task DeleteAsync(int id)
		{
			await unitOfWork.Makes.DeleteAsync(id);
		}
	}
}
