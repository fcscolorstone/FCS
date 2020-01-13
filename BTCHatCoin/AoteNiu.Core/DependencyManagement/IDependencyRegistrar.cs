using Autofac;
using AoteNiu.Core.Infrastructure;

namespace AoteNiu.Core.DependencyManagement
{
    public interface IDependencyRegistrar
    {
        /// <summary>
        /// Lets the implementor register dependencies withing the global dependency container
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="typeFinder"></param>
        void Register(ContainerBuilder builder);

        int Order { get; }
    }
}
