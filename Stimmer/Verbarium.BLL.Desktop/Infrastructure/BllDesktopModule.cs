using Ninject.Modules;
using Verbarium.BLL.Desktop.Interfaces;
using Verbarium.BLL.Desktop.Services;

namespace Verbarium.BLL.Desktop.Infrastructure
{
    public class BllDesktopModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IClassifierService>().To<ClassifierService>();
            Bind<IQuoteService>().To<QuoteService>();
            Bind<IWordService>().To<WordService>();
        }
    }
}
