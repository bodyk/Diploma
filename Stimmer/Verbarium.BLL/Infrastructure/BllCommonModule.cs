using Ninject.Modules;
using Verbarium.BLL.Interfaces;
using Verbarium.BLL.Services;
using Verbarium.DAL.Infrastructure;

namespace Verbarium.BLL.Infrastructure
{
    public class BllCommonModule : NinjectModule
    {
        public override void Load()
        {
            Kernel?.Load(new INinjectModule[] {new DataAccessModule()});
            Bind<IClassifierServiceCrud>().To<ClassifierServiceCrud>();
            Bind<IQuoteServiceCrud>().To<QuoteServiceCrud>();
            Bind<IWordServiceCrud>().To<WordServiceCrud>();
        }
    }
}
