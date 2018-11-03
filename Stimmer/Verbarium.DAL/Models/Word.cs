using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Verbarium.DAL.Interfaces;

namespace Verbarium.DAL.Models
{
    public class Word : IEntity
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        
        public string Description { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? CreationTime { get; set; } = DateTime.Now;
        
        public virtual List<Quote> Quotes { get; set; }

        public virtual List<Classifier> Classifiers { get; set; }
    }
}
