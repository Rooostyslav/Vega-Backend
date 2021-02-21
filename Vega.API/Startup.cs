using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Vega.BLL.BusinessModels;
using Vega.BLL.BusinessModels.Settings;
using Vega.BLL.Infrastructure;

namespace Vega.API
{
	public class Startup
	{
		public IConfiguration Configuration { get; }

		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public void ConfigureServices(IServiceCollection services)
		{
			string connectionString = Configuration.GetConnectionString("DefaultConnection");
			services.AddContextService(connectionString);

			services.AddAutoMapper();

			services.AddServices();

			services.Configure<PhotoSettings>(Configuration.GetSection("PhotoSettings"));

			services.AddControllers()
				.AddNewtonsoftJson(option => 
				option.SerializerSettings.ReferenceLoopHandling 
				= Newtonsoft.Json.ReferenceLoopHandling.Ignore);

			services.AddCors(options =>
			{
				options.AddPolicy("CorsPolicy",
					builder => builder.AllowAnyOrigin()
					.AllowAnyMethod()
					.AllowAnyHeader());
			});
		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseHttpsRedirection();

			app.UseRouting();

			app.UseAuthorization();

			app.UseStaticFiles();

			app.UseCors("CorsPolicy");

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
