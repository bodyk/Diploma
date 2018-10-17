using System.Collections.Generic;
using UkrainianStemmer.Interfaces;

namespace UkrainianStemmer.Services
{
    public class Stemmer
    {
        public string Version { get; set; } = "0.01";
        public int StemCaching { get; set; }
        public List<string> StemCache { get; set; } = new List<string>();
        public string Vowels { get; set; } = "/аеиоуюяіїє/";
        public string PerfectiveGround { get; set; } = "/((ив|ивши|ившись|ыв|ывши|ывшись((?<=[ая])(в|вши|вшись)))$/";
        public string Reflexive { get; set; } = "/(с[яьи])$/";  // http://uk.wikipedia.org/wiki/Рефлексивне_дієслово
        public string Adjective { get; set; } = "/(ими|ій|ий|а|е|ова|ове|ів|є|їй|єє|еє|я|ім|ем|им|ім|их|іх|ою|йми|іми|у|ю|ого|ому|ої)$/"; //http://uk.wikipedia.org/wiki/Прикметник + http://wapedia.mobi/uk/Прикметник
        public string Participle { get; set; } = "/(ий|ого|ому|им|ім|а|ій|у|ою|ій|і|их|йми|их)$/"; //http://uk.wikipedia.org/wiki/Дієприкметник
        public string Verb { get; set; } = "/(сь|ся|ив|ать|ять|у|ю|ав|али|учи|ячи|вши|ши|е|ме|ати|яти|є)$/"; //http://uk.wikipedia.org/wiki/Дієслово
        public string Noun { get; set; } = "/(а|ев|ов|е|ями|ами|еи|и|ей|ой|ий|й|иям|ям|ием|ем|ам|ом|о|у|ах|иях|ях|ы|ь|ию|ью|ю|ия|ья|я|і|ові|ї|ею|єю|ою|є|еві|ем|єм|ів|їв|\'ю)$/"; //http://uk.wikipedia.org/wiki/Іменник
        public string Rvre { get; set; } = "/^(.*?[аеиоуюяіїє])(.*)$/";
        public string Derivational { get; set; } = "/[^аеиоуюяіїє][аеиоуюяіїє]+[^аеиоуюяіїє]+[аеиоуюяіїє].*(?<=о)сть?$/";

        public string Execute(string word, bool useStopWords)
        {
            return null;
        }
    }
}
