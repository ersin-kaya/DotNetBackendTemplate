using System;
using DotNetBackendTemplate.Business.Abstract;
using DotNetBackendTemplate.Business.ValidationRules.FluentValidation;
using DotNetBackendTemplate.Core.Aspects.Autofac.Caching;
using DotNetBackendTemplate.Core.Aspects.Autofac.Validation;
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

        [CacheRemoveAspect("IAssetService.Get")]
        [ValidationAspect(typeof(AssetValidator))]
        public IResult Add(Asset asset)
        {
            _assetDal.Add(asset);
            return new SuccessResult();
        }

        [CacheRemoveAspect("IAssetService.Get")]
        public IResult Delete(Asset asset)
        {
            _assetDal.Delete(asset);
            return new SuccessResult();
        }

        [CacheAspect]
        public IDataResult<List<Asset>> GetAll()
        {
            return new SuccessDataResult<List<Asset>>(_assetDal.GetAll());
        }

        [CacheRemoveAspect("IAssetService.Get")]
        [ValidationAspect(typeof(AssetValidator))]
        public IResult Update(Asset asset)
        {
            _assetDal.Update(asset);
            return new SuccessResult();
        }
    }
}

