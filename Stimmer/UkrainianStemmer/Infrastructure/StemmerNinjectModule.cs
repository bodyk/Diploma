using Ninject.Modules;
using UkrainianStemmer.Interfaces;
using UkrainianStemmer.Services;

namespace UkrainianStemmer.Infrastructure
{
    public class StemmerNinjectModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IStemmerService>().To<StemmerService>();
        }
    }
}
