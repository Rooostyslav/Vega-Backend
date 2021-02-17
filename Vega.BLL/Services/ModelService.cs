using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using Vega.BLL.DTO;
using Vega.BLL.Interfaces;
using Vega.DAL.Entity;
using Vega.DAL.Interfaces;

namespace Vega.BLL.Services
{
	public class ModelService : IModelService
	{
		private readonly IUnitOfWork unitOfWork;
		private readonly IMapper mapper;

		public ModelService(IUnitOfWork unitOfWork, IMapper mapper)
		{
			this.unitOfWork = unitOfWork;
			this.mapper = mapper;
		}

		public async Task<IEnumerable<ModelDTO>> GetModelsAsync()
		{
			var models = await unitOfWork.Models.GetAllAsync();
			return mapper.Map<IEnumerable<ModelDTO>>(models);
		}

		public async Task<ModelDTO> GetModelAsync(int id)
		{
			var model = await unitOfWork.Models.GetAsync(id);
			return mapper.Map<ModelDTO>(model);
		}

		public async Task CreateAsync(ModelDTO modelDTO)
		{
			var model = mapper.Map<Model>(modelDTO);
			await unitOfWork.Models.CreateAsync(model);
		}

		public async Task UpdateAsync(int id, ModelDTO modelDTO)
		{
			var model = mapper.Map<Model>(modelDTO);
			model.Id = id;
			await unitOfWork.Models.UpdateAsync(model);
		}

		public async Task DeleteAsync(int id)
		{
			await unitOfWork.Models.DeleteAsync(id);
		}
	}
}
