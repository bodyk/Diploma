using System;
using System.Collections.Generic;
using Verbarium.BLL.Interfaces;

namespace Verbarium.BLL.DTOs
{
    public class WordDto : IDtoEntity
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public string Description { get; set; }

        public DateTime CreationTime { get; set; }
        
        public virtual List<QuoteDto> Quotes { get; set; }

        public virtual List<ClassifierDto> Classifiers { get; set; }
    }
}
