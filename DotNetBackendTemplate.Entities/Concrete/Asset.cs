using System;
using DotNetBackendTemplate.Core.Entities;

namespace DotNetBackendTemplate.Entities.Concrete
{
	public class Asset : IEntity
	{
		public int AssetId { get; set; }
		public string AssetName { get; set; }
		public string AssetIcon { get; set; }
	}
}

