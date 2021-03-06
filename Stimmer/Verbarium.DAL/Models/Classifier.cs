using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Verbarium.DAL.Interfaces;

namespace Verbarium.DAL.Models
{
    public class Classifier : IEntity
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public string Description { get; set; }

        [ForeignKey("ParentClassifier")]
        public int? ParentId { get; set; }

        public virtual Classifier ParentClassifier { get; set; }

        public virtual List<Classifier> Classifiers { get; set; }

        public virtual List<Word> Words { get; set; }
    }
}
