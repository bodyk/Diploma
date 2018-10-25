using System.Collections.Generic;
using System.Data.Entity;
using Verbarium.DAL.Models;

namespace Verbarium.DAL.Context
{
    public class ClassifierDbInitializer : DropCreateDatabaseIfModelChanges<VerbariumContext>
    {
        protected override void Seed(VerbariumContext context)
        {
            var defaultClassifiers = new List<Classifier>
            {
                new Classifier
                {
                    Name = "Морфологічна",
                    Classifiers = new List<Classifier>
                    {
                        new Classifier
                        {
                            Name = "Дієслово"
                        },
                        new Classifier
                        {
                            Name = "Іменник"
                        },
                        new Classifier
                        {
                            Name = "Прикметник"
                        }
                    }
                },
                new Classifier
                {
                    Name = "Спосіб творення",
                    Classifiers = new List<Classifier>
                    {
                        new Classifier
                        {
                            Name = "Безсуфіксальний"
                        },
                        new Classifier
                        {
                            Name = "Префіксальний"
                        },
                        new Classifier
                        {
                            Name = "Суфіксальний"
                        },
                        new Classifier
                        {
                            Name = "Префіксально-суфіксальний"
                        }
                    }
                },
            };

            context.Classifiers.AddRange(defaultClassifiers);

            base.Seed(context);
        }
    }
}
