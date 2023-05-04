using System;
using DotNetBackendTemplate.Business.Abstract;
using DotNetBackendTemplate.Core.Utilities.Results.Abstract;
using DotNetBackendTemplate.Core.Utilities.Results.Concrete;
using DotNetBackendTemplate.DataAccess.Abstract;
using DotNetBackendTemplate.Entities.Concrete;

namespace DotNetBackendTemplate.Business.Concrete
{
	public class AssetManager : IAssetService
	{
        IAssetDal _assetDal;

		public AssetManager(IAssetDal assetDal)
		{
            _assetDal = assetDal;
		}

        public IResult Add(Asset asset)
        {
            _assetDal.Add(asset);
            return new SuccessResult();
        }

        public IResult Delete(Asset asset)
        {
            _assetDal.Delete(asset);
            return new SuccessResult();
        }

        public IDataResult<List<Asset>> GetAll()
        {
            return new SuccessDataResult<List<Asset>>(_assetDal.GetAll());
        }

        public IResult Update(Asset asset)
        {
            _assetDal.Update(asset);
            return new SuccessResult();
        }
    }
}

