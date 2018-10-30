using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verbarium.BLL.DTOs;
using Verbarium.DAL.Models;

namespace Verbarium.BLL.Extensions.Mapper
{
    public static class ClassifierMapper
    {
        public static ClassifierDto ToDto(this Classifier entity)
        {
            return new ClassifierDto
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description,
                ParentId = entity.ParentId,
                Classifiers = entity.Classifiers?.Select(e => e.ToDto()).ToList()
            };
        }

        public static Classifier ToEntity(this ClassifierDto dto)
        {
            return new Classifier
            {
                Id = dto.Id,
                Name = dto.Name,
                Description = dto.Description,
                Classifiers = dto.Classifiers?.Select(e => e.ToEntity()).ToList(),
                ParentId = dto.ParentId
            };
        }
    }
}
