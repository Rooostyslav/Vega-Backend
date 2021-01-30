using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Vega.BLL.Interfaces;
using Vega.BLL.Services;
using Vega.DAL.EF;
using Vega.DAL.Interfaces;
using Vega.DAL.Repositories;

namespace Vega.BLL.Infrastructure
{
	public static class ProviderExtensions
	{
		public static void AddContextService(this IServiceCollection services, string connectionString)
		{
			services.AddDbContext<VegaDbContext>(options =>
				options.UseSqlServer(connectionString));

			services.AddSingleton<IUnitOfWork>(new UnitOfWork(connectionString));
		}

		public static void AddAutoMapper(this IServiceCollection services)
		{
			var mapperConfig = new MapperConfiguration(mc =>
			{
				mc.AddProfile(new MappingProfile());
			});

			IMapper mapper = mapperConfig.CreateMapper();
			services.AddSingleton(mapper);
		}

		public static void AddServices(this IServiceCollection services)
		{
			services.AddSingleton<IMakeService, MakeService>();
			services.AddSingleton<IModelService, ModelService>();
			services.AddSingleton<IFeatureService, FeatureService>();
		}
	}
}
