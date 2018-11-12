using Ninject;
using Ninject.Modules;
using UkrainianStemmer.Interfaces;
using UkrainianStemmer.Services;
using Verbarium.BLL.Infrastructure;

namespace UkrainianStemmer.Infrastructure
{
    public class StemmerNinjectModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IStemmerService>().To<StemmerService>();

            var standardKernel = new StandardKernel();
            standardKernel.Load(new BllCommonModule());
        }
    }
}
