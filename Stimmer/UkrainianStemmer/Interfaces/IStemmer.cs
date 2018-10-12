namespace UkrainianStemmer.Interfaces
{
    public interface IStemmer
    {
        string Execute(string word, bool useStopWords);
    }
}
