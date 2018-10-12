using UkrainianStemmer.Interfaces;

namespace UkrainianStemmer.Services
{
    internal class StemmerService : IStemmerService
    {
        private readonly IStemmer _stemmer;

        public StemmerService(IStemmer stemmer)
        {
            _stemmer = stemmer;
        }

        private bool S(string s)
        {
            return true;
        }
    }
}
