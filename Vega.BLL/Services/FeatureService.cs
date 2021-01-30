using AutoMapper;
using System.Collections.Generic;
using Vega.BLL.DTO;
using Vega.BLL.Interfaces;
using Vega.DAL.Entity;
using Vega.DAL.Interfaces;

namespace Vega.BLL.Services
{
	public class FeatureService : IFeatureService
	{
		private readonly IUnitOfWork unitOfWork;
		private readonly IMapper mapper;

		public FeatureService(IUnitOfWork unitOfWork, IMapper mapper)
		{
			this.unitOfWork = unitOfWork;
			this.mapper = mapper;
		}

		public void Delete(int id)
		{
			unitOfWork.Features.Delete(id);
			unitOfWork.Save();
		}

		public FeatureDTO GetFeature(int id)
		{
			var feature = unitOfWork.Features.Get(id);
			return mapper.Map<FeatureDTO>(feature);
		}

		public IEnumerable<FeatureDTO> GetFeatures()
		{
			var features = unitOfWork.Features.GetAll();
			return mapper.Map<IEnumerable<FeatureDTO>>(features);
		}

		public void Insert(FeatureDTO featureDTO)
		{
			var feature = mapper.Map<Feature>(featureDTO);
			unitOfWork.Features.Insert(feature);
			unitOfWork.Save();
		}

		public void Update(FeatureDTO featureDTO)
		{
			var feature = mapper.Map<Feature>(featureDTO);
			unitOfWork.Features.Update(feature);
			unitOfWork.Save();
		}
	}
}
