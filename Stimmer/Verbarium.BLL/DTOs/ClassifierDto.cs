using System.Collections.Generic;
using Verbarium.BLL.Interfaces;

namespace Verbarium.BLL.DTOs
{
    public class ClassifierDto : IDtoEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

        public virtual List<ClassifierDto> Classifiers { get; set; }
    }
}
