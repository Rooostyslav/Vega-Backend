using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
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

		public async Task<IEnumerable<FeatureDTO>> GetFeaturesAsync()
		{
			var features = await unitOfWork.Features.GetAllAsync();
			return mapper.Map<IEnumerable<FeatureDTO>>(features);
		}

		public async Task<FeatureDTO> GetFeatureAsync(int id)
		{
			var feature = await unitOfWork.Features.GetAsync(id);
			return mapper.Map<FeatureDTO>(feature);
		}

		public async Task CreateAsync(FeatureDTO featureDTO)
		{
			var feature = mapper.Map<Feature>(featureDTO);
			await unitOfWork.Features.CreateAsync(feature);
		}

		public async Task UpdateAsync(int id, FeatureDTO featureDTO)
		{
			var feature = mapper.Map<Feature>(featureDTO);
			feature.Id = id;
			await unitOfWork.Features.UpdateAsync(feature);
		}

		public async Task DeleteAsync(int id)
		{
			await unitOfWork.Features.DeleteAsync(id);
		}
	}
}
