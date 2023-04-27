using System;
using Autofac;
using DotNetBackendTemplate.Business.Abstract;
using DotNetBackendTemplate.Business.Concrete;
using DotNetBackendTemplate.DataAccess.Abstract;
using DotNetBackendTemplate.DataAccess.Concrete.EntityFramework;

namespace DotNetBackendTemplate.Business.DependencyResolvers.Autofac
{
	public class AutofacBusinessModule : Module
	{
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<EfSomeFeatureEntityDal>().As<ISomeFeatureEntityDal>().SingleInstance();
            builder.RegisterType<SomeFeatureEntityManager>().As<ISomeFeatureEntityService>().SingleInstance();
        }
    }
}

