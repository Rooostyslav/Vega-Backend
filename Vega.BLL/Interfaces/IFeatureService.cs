using System;
using System.Collections.Generic;
using System.Text;
using Vega.BLL.DTO;

namespace Vega.BLL.Interfaces
{
	public interface IFeatureService
	{
		void Insert(FeatureDTO featureDTO);
		void Update(FeatureDTO featureDTO);
		void Delete(int id);
		FeatureDTO GetFeature(int id);
		IEnumerable<FeatureDTO> GetFeatures();
	}
}
