using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Vega.DAL.EF;
using Vega.DAL.Entity;
using Vega.DAL.Interfaces;

namespace Vega.DAL.Repositories
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly VegaDbContext vegaDbContext;
		private MakeRepository makeRepository;
		private ModelRepository modelRepository;
		private FeatureRepository featureRepository;
		private VehicleRepository vehicleRepository;
		private ContactRepository contactRepository;
		private PhotoRepository photoRepository;

		public UnitOfWork(string connectionString)
		{
			var optionsBuilder = new DbContextOptionsBuilder<VegaDbContext>();
			optionsBuilder.UseSqlServer(connectionString);
			vegaDbContext = new VegaDbContext(optionsBuilder.Options);
		}

		public IRepository<Make> Makes
		{
			get
			{
				if (makeRepository == null)
				{
					makeRepository = new MakeRepository(vegaDbContext);
				}

				return makeRepository;
			}
		}

		public IRepository<Model> Models
		{
			get
			{
				if (modelRepository == null)
				{
					modelRepository = new ModelRepository(vegaDbContext);
				}

				return modelRepository;
			}
		}


		public IRepository<Feature> Features
		{
			get
			{
				if (featureRepository == null)
				{
					featureRepository = new FeatureRepository(vegaDbContext);
				}

				return featureRepository;
			}
		}

		public IRepository<Vehicle> Vehicles
		{
			get
			{
				if (vehicleRepository == null)
				{
					vehicleRepository = new VehicleRepository(vegaDbContext);
				}

				return vehicleRepository;
			}
		}

		public IRepository<Contact> Contacts
		{
			get
			{
				if (contactRepository == null)
				{
					contactRepository = new ContactRepository(vegaDbContext);
				}

				return contactRepository;
			}
		}

		public IRepository<Photo> Photos
		{
			get
			{
				if (photoRepository == null)
				{
					photoRepository = new PhotoRepository(vegaDbContext);
				}

				return photoRepository;
			}
		}

		public async Task SaveAsync()
		{
			await vegaDbContext.SaveChangesAsync();
		}
	}
}
