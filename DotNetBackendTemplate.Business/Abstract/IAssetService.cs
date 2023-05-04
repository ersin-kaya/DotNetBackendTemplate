using System;
using System.Diagnostics.Metrics;
using DotNetBackendTemplate.Core.Utilities.Results.Abstract;
using DotNetBackendTemplate.Entities.Concrete;

namespace DotNetBackendTemplate.Business.Abstract
{
	public interface IAssetService
	{
        IDataResult<List<Asset>> GetAll();
        IResult Add(Asset asset);
        IResult Update(Asset asset);
        IResult Delete(Asset asset);
        IResult TransactionalOperation(Asset asset);
    }
}

