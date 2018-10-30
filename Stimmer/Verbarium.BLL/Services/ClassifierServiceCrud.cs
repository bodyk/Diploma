using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Verbarium.BLL.DTOs;
using Verbarium.BLL.Extensions.Mapper;
using Verbarium.BLL.Interfaces;
using Verbarium.BLL.Services.Base;
using Verbarium.DAL.Interfaces;
using Verbarium.DAL.Models;

namespace Verbarium.BLL.Services
{
    public class ClassifierServiceCrud 
        : BaseServiceCrud<Classifier, ClassifierDto>, IClassifierServiceCrud
    {
        public ClassifierServiceCrud(IUnitOfWork unitOfWork) : base(unitOfWork, "Classifiers")
        {
        }

        public override IEnumerable<ClassifierDto> ConvertToDtos(IEnumerable<Classifier> entities)
        {
            return entities.Select(entity => entity.ToDto());
        }

        public override IEnumerable<Classifier> ConvertToEntities(IEnumerable<ClassifierDto> dtos)
        {
            return dtos.Select(dto => dto.ToEntity());
        }

        public override ClassifierDto ConvertToDto(Classifier entity)
        {
            return entity.ToDto();
        }

        public override Classifier ConvertToEntity(ClassifierDto dto)
        {
            return dto.ToEntity();
        }
    }
}
