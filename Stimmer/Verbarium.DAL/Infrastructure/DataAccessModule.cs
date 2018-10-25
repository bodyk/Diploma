using Ninject.Extensions.Factory;
using Ninject.Modules;
using Verbarium.DAL.Context;
using Verbarium.DAL.Interfaces;
using Verbarium.DAL.Realisations;

namespace Verbarium.DAL.Infrastructure
{
    public class DataAccessModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IRepositoryFactory>().ToFactory();
            Bind<VerbariumContext>().ToSelf();
            Bind(typeof(IGenericRepository<>)).To(typeof(GenericRepository<>));
            Bind<IUnitOfWork>().To<UnitOfWork>();
        }
    }
}
