using AutoMapper;
using Vega.BLL.DTO;
using Vega.DAL.Entity;

namespace Vega.BLL.Infrastructure
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			CreateMap<Make, MakeDTO>().ReverseMap();
			CreateMap<Model, ModelDTO>().ReverseMap();
			CreateMap<Feature, FeatureDTO>().ReverseMap();
		}
	}
}
