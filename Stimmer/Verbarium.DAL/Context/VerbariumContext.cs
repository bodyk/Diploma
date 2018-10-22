using System.Data.Entity;
using Verbarium.DAL.Models;

namespace Verbarium.DAL.Context
{
    public class VerbariumContext : DbContext
    {
        public VerbariumContext()
            : base("name=VerbariumContext")
        {

        }

        public virtual DbSet<Classifier> Classifiers { get; set; }
        public virtual DbSet<Quote> Quotes { get; set; }
        public virtual DbSet<Word> Words { get; set; }
    }
}
