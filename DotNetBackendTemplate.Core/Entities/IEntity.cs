using System;
namespace DotNetBackendTemplate.Core.Entities
{
	public interface IEntity
	{
		DateTime CreatedTime { get; set; }
		DateTime LastUpdatedTime { get; set; }
	}
}

