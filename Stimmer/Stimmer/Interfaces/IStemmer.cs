namespace Stimmer.Interfaces
{
    public interface IStemmer
    {
        string Execute(string word, bool useStopWords);
    }
}
