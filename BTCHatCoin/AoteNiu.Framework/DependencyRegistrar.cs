using AoteNiu.Core.DependencyManagement;
using AoteNiu.Data;
using AoteNiu.Service;
using Autofac;
using Module = Autofac.Module;

namespace AoteNiu.Framework
{
    public class DependencyRegistrar : IDependencyRegistrar
    {
        public void Register(ContainerBuilder builder)
        {
            // modules
            builder.RegisterModule(new CoreModule());
            builder.RegisterModule(new MongoDBModule());
        }

        public int Order 
        {
            get { return -100; }
        }
    }

    #region Modules

    public class CoreModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // InnerAPI
            builder.RegisterType<CoinPriceService>().As<ICoinPriceService>().InstancePerLifetimeScope();
        }
    }

    public class MongoDBModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(DefaultMongoRepository<>)).As(typeof(IAltNiuRepository<>)).InstancePerLifetimeScope();
        }
    }

    #endregion
}
