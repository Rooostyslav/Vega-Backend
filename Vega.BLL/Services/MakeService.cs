using AutoMapper;
using System.Collections.Generic;
using Vega.BLL.DTO;
using Vega.BLL.Interfaces;
using Vega.DAL.Entity;
using Vega.DAL.Interfaces;

namespace Vega.BLL.Services
{
	public class MakeService : IMakeService
	{
		private readonly IUnitOfWork unitOfWork;
		private readonly IMapper mapper;

		public MakeService(IUnitOfWork unitOfWork, IMapper mapper)
		{
			this.unitOfWork = unitOfWork;
			this.mapper = mapper;
		}

		public void Delete(int id)
		{
			unitOfWork.Makes.Delete(id);
			unitOfWork.Save();
		}

		public MakeDTO GetMake(int id)
		{
			var make = unitOfWork.Makes.Get(id);
			return mapper.Map<MakeDTO>(make);
		}

		public IEnumerable<MakeDTO> GetMakes()
		{
			var makes = unitOfWork.Makes.GetAll();
			return mapper.Map<IEnumerable<MakeDTO>>(makes);
		}

		public void Insert(MakeDTO makekDTO)
		{
			var make = mapper.Map<Make>(makekDTO);
			unitOfWork.Makes.Insert(make);
			unitOfWork.Save();
		}

		public void Update(MakeDTO makekDTO)
		{
			var make = mapper.Map<Make>(makekDTO);
			unitOfWork.Makes.Update(make);
			unitOfWork.Save();
		}
	}
}
