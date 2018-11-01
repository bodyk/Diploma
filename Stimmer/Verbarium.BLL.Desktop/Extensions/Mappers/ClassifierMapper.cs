using System.Linq;
using Verbarium.BLL.DTOs;
using Verbarium.DAL.Models;

namespace Verbarium.BLL.Desktop.Extensions.Mappers
{
    public static class ClassifierMapper
    {
        public static Classifier ToClassifier(this ClassifierDto dto)
        {
            return new Classifier
            {
                Id = dto.Id,
                Name = dto.Name,
                Description = dto.Description,
                ParentId = dto.ParentId,
                Classifiers = dto.Classifiers.Select(cl => cl.ToClassifier()).ToList()
            };
        }
    }
}
