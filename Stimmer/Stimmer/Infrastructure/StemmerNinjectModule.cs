﻿using Ninject.Modules;
using Stimmer.Interfaces;
using Stimmer.Services;

namespace Stimmer.Infrastructure
{
    public class StemmerNinjectModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IStemmer>().To<Services.Stemmer>();
            Bind<IStemmerService>().To<StemmerService>();
        }
    }
}
