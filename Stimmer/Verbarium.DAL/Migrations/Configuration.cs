﻿using System.Collections.Generic;
using Verbarium.DAL.Models;

namespace Verbarium.DAL.Migrations
{
    using System.Data.Entity.Migrations;

    public sealed class Configuration : DbMigrationsConfiguration<Verbarium.DAL.Context.VerbariumContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Verbarium.DAL.Context.VerbariumContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
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
            context.SaveChanges();
            base.Seed(context);
        }
    }
}
