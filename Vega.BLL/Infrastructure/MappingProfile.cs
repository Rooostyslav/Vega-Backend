using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using Vega.BLL.DTO;
using Vega.BLL.DTO.ContactModels;
using Vega.BLL.DTO.VehicleModels;
using Vega.DAL.Entity;
using KeyValuePair = Vega.BLL.DTO.KeyValuePair;

namespace Vega.BLL.Infrastructure
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			CreateMap<Make, MakeDTO>().ReverseMap();
			CreateMap<Model, ModelDTO>().ReverseMap();
			CreateMap<Feature, FeatureDTO>().ReverseMap();
			CreateMap<Vehicle, VehicleDTO>().ReverseMap();
			CreateMap<Contact, ContactDTO>().ReverseMap();

			CreateMap<Vehicle, ViewVehicleDTO>()
				.ForMember(v => v.Make, opt => 
					opt.MapFrom(vv => new KeyValuePair() { Id = vv.Model.MakeId, Name = vv.Model.Make.Name }))
				.ForMember(v => v.Model, opt => 
					opt.MapFrom(vv => new KeyValuePair() { Id = vv.ModelId, Name = vv.Model.Name }))
				.ForMember(v => v.Features, opt => opt.Ignore())
				.AfterMap((v, vv) =>
				{
					vv.Features = new List<KeyValuePair>(v.Features.Select(f => new KeyValuePair() { Id = f.Id, Name = f.Name }).ToList());
				});

			CreateMap<CreateUpdateVehicleDTO, Vehicle>()
				.ForMember(v => v.Features, opt => opt.Ignore());

			CreateMap<Contact, ViewContactDTO>();
		}
	}
}
