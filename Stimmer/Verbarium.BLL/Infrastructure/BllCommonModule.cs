using Ninject.Modules;
using Verbarium.BLL.Interfaces;
using Verbarium.BLL.Services;

namespace Verbarium.BLL.Infrastructure
{
    public class BllCommonModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IClassifierServiceCrud>().To<ClassifierServiceCrud>();
            Bind<IQuoteServiceCrud>().To<QuoteServiceCrud>();
            Bind<IWordServiceCrud>().To<WordServiceCrud>();
        }
    }
}
