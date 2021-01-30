using AutoMapper;
using System.Collections.Generic;
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

		public void Delete(int id)
		{
			unitOfWork.Models.Delete(id);
			unitOfWork.Save();
		}

		public ModelDTO GetModel(int id)
		{
			var model = unitOfWork.Models.Get(id);
			return mapper.Map<ModelDTO>(model);
		}

		public IEnumerable<ModelDTO> GetModels()
		{
			var models = unitOfWork.Models.GetAll();
			return mapper.Map<IEnumerable<ModelDTO>>(models);
		}

		public void Insert(ModelDTO modelDTO)
		{
			var model = mapper.Map<Model>(modelDTO);
			unitOfWork.Models.Insert(model);
			unitOfWork.Save();
		}

		public void Update(ModelDTO modelDTO)
		{
			var model = mapper.Map<Model>(modelDTO);
			unitOfWork.Models.Update(model);
			unitOfWork.Save();
		}
	}
}
