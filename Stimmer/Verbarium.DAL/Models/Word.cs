using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Verbarium.DAL.Models
{
    public class Word
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        
        public string Description { get; set; }

        public DateTime CreationTime { get; set; }
        
        public virtual List<Quote> Quotes { get; set; }

        public virtual List<Classifier> Classifiers { get; set; }
    }
}