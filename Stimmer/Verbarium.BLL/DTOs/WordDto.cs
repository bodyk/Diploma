using System;
using System.Collections.Generic;

namespace Verbarium.BLL.DTOs
{
    public class WordDto
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public string Description { get; set; }

        public DateTime CreationTime { get; set; }
        
        public virtual List<QuoteDto> Quotes { get; set; }

        public virtual List<ClassifierDto> Classifiers { get; set; }
    }
}
