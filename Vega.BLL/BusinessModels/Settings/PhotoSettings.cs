﻿using System.IO;
using System.Linq;

namespace Vega.BLL.BusinessModels.Settings
{
	public class PhotoSettings
	{
		public int MaxBytes { get; set; }

		public string[] AcceptedFileTypes { get; set; }

		public bool IsSupportedFile(string fileName)
		{
			return AcceptedFileTypes.Any(s => s == Path.GetExtension(fileName));
		}
	}
}
