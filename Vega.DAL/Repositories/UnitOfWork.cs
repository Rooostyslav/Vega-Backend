using Microsoft.EntityFrameworkCore;
using Vega.DAL.EF;
using Vega.DAL.Entity;
using Vega.DAL.Interfaces;

namespace Vega.DAL.Repositories
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly VegaDbContext vegaDbContext;
		private MakeRepository MakeRepository;
		private ModelRepository ModelRepository;
		private FeatureRepository FeatureRepository;
		private VehicleRepository VehicleRepository;
		private ContactRepository ContactRepository;

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
				if (MakeRepository == null)
				{
					MakeRepository = new MakeRepository(vegaDbContext);
				}

				return MakeRepository;
			}
		}

		public IRepository<Model> Models
		{
			get
			{
				if (ModelRepository == null)
				{
					ModelRepository = new ModelRepository(vegaDbContext);
				}

				return ModelRepository;
			}
		}


		public IRepository<Feature> Features
		{
			get
			{
				if (FeatureRepository == null)
				{
					FeatureRepository = new FeatureRepository(vegaDbContext);
				}

				return FeatureRepository;
			}
		}

		public IRepository<Vehicle> Vehicles
		{
			get
			{
				if (VehicleRepository == null)
				{
					VehicleRepository = new VehicleRepository(vegaDbContext);
				}

				return VehicleRepository;
			}
		}

		public IRepository<Contact> Contacts
		{
			get
			{
				if (ContactRepository == null)
				{
					ContactRepository = new ContactRepository(vegaDbContext);
				}

				return ContactRepository;
			}
		}

		public void Save()
		{
			vegaDbContext.SaveChanges();
		}
	}
}
