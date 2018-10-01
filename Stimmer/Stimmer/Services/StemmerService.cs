using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stimmer.Interfaces;

namespace Stimmer.Services
{
    internal class StemmerService : IStemmerService
    {
        private readonly IStemmer _stemmer;

        public StemmerService(IStemmer stemmer)
        {
            _stemmer = stemmer;
        }
    }
}
