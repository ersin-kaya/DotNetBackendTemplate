using System;
using System.Diagnostics.Metrics;
using DotNetBackendTemplate.Business.Abstract;
using DotNetBackendTemplate.Business.BusinessAspects.Autofac;
using DotNetBackendTemplate.Business.ValidationRules.FluentValidation;
using DotNetBackendTemplate.Core.Aspects.Autofac.Caching;
using DotNetBackendTemplate.Core.Aspects.Autofac.Performance;
using DotNetBackendTemplate.Core.Aspects.Autofac.Transaction;
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

        [SecuredOperation("asset.add,asset,admin")]
        [CacheRemoveAspect("IAssetService.Get")]
        [ValidationAspect(typeof(AssetValidator))]
        public IResult Add(Asset asset)
        {
            _assetDal.Add(asset);
            return new SuccessResult();
        }

        [SecuredOperation("asset.delete,asset,admin")]
        [CacheRemoveAspect("IAssetService.Get")]
        public IResult Delete(Asset asset)
        {
            _assetDal.Delete(asset);
            return new SuccessResult();
        }

        [CacheAspect]
        [PerformanceAspect(3)]
        public IDataResult<List<Asset>> GetAll()
        {
            return new SuccessDataResult<List<Asset>>(_assetDal.GetAll());
        }

        [SecuredOperation("asset.update,asset,admin")]
        [CacheRemoveAspect("IAssetService.Get")]
        [ValidationAspect(typeof(AssetValidator))]
        public IResult Update(Asset asset)
        {
            _assetDal.Update(asset);
            return new SuccessResult();
        }

        [TransactionScopeAspect]
        [SecuredOperation("admin")]
        [CacheRemoveAspect("IAssetService.Get")]
        [ValidationAspect(typeof(AssetValidator))]
        public IResult TransactionalOperation(Asset asset)
        {
            _assetDal.Add(asset);

            //For test
            asset.AssetId = 0;
            if (asset.AssetName == "TransactionTest")
            {
                throw new Exception("TransactionalOperation could not be completed!");
            }
            asset.AssetName += "#TransactionTest";
            _assetDal.Add(asset);
            return new SuccessResult("TransactionalOperation successfully completed.");
        }
    }
}

