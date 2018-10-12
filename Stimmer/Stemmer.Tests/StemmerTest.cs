using System.Collections.Generic;
using System.IO;
using System.Text;
using NUnit.Framework;
using UkrainianStemmer.Services;

namespace Stemmer.Tests
{
    [TestFixture]
    public class StemmerTest
    {
        private Dictionary<string, string> index;

        string resultFile = "Data\\Results.txt";
        string testDataFile = "Data\\TestUkrainian.txt";

        [Test]
        public void TestFromFile()
        {

            index = new Dictionary<string, string>();
            var stemmer = new SnowballProgram();

            var reader = new StreamReader(testDataFile);

            var output = new StreamWriter(resultFile);

            StringBuilder input = new StringBuilder();

            int character;
            while ((character = reader.Read()) != -1)
            {
                char ch = (char)character;
                if (char.IsWhiteSpace(ch))
                {



                    var reworked = input.Replace("[^а-яА-ЯїЇґҐєЄіІ'-]", "");

                    if (reworked.Length > 0 && !char.IsWhiteSpace(reworked[0]))
                    {
                        stemmer.setCurrent(reworked);
                        stemmer.stem();

                        addWord(reworked.ToString(), stemmer.getCurrent());

                    }
                    input = input.Remove(0, input.Length);
                }
                else
                {
                    input.Append(ch);
                }
            }

            foreach (var pair in index)
            {
                if (pair.Value.Length > 0)
                {
                    output.Write(pair.Value + " " + pair + "\n");
                }
            }

            output.Flush();

            List<string> rows = new List<string>();
            StreamReader read = new StreamReader(new FileStream(resultFile, FileMode.OpenOrCreate));

            string s;
            while ((s = read.ReadLine()) != null)
                rows.Add(s);

            rows.Sort();

            StreamWriter writer = new StreamWriter(resultFile);
            foreach (string cur in rows)
                writer.Write(cur + "\n");

            reader.Close();
            output.Close();
            read.Close();
            writer.Close();

        }

        public void addWord(string start, string stemmed)
        {
            if (!index.ContainsKey(start))
            {
                index.Add(start, stemmed);
            }
        }
    }
}
