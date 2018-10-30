using Ninject;
using System.Collections.Generic;
using Verbarium.BLL.Desktop.Interfaces;
using Verbarium.BLL.DTOs;
using Verbarium.BLL.Services;
using Verbarium.DAL.Infrastructure;
using Verbarium.DAL.Interfaces;

namespace Verbarium.BLL.Desktop.Services
{
    public class ClassifierService : ClassifierServiceCrud, IClassifierService
    {
        public List<ClassifierDto> GetAllClassifiers(int rootId = -1)
        {
            throw new System.NotImplementedException();
        }

        public List<ClassifierDto> GetRootClassifiers()
        {
            throw new System.NotImplementedException();
        }

        public List<WordDto> GetClassifStartsWith(string startPart)
        {
            throw new System.NotImplementedException();
        }

        public List<ClassifierDto> GetPathToClassifier(int parentId = -1)
        {
            throw new System.NotImplementedException();
        }

        public int GetParentId(int classifId)
        {
            throw new System.NotImplementedException();
        }

        public bool AddClassifier(string name, int parentId, ref int classifierId, string description = "")
        {
            classifierId = Create(new ClassifierDto
            {
                Name = name,
                Description = description,
                ParentId = parentId == (-1) ? (int?) null : parentId
            }).Id;

            return true;
        }

        public bool AddWord(int wordId, List<ClassifierDto> classifiers)
        {
            throw new System.NotImplementedException();
        }

        public bool DeleteWordFromClassifier(int wordId, int classifierId)
        {
            throw new System.NotImplementedException();
        }

        public bool DeleteWordFromClassifier(int wordId, ClassifierDto dto)
        {
            throw new System.NotImplementedException();
        }

        public bool NormalizeClassifiers()
        {
            throw new System.NotImplementedException();
        }

        public bool DeleteClassifier(int classifierId)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteAllClassifiers()
        {
            throw new System.NotImplementedException();
        }

        public ClassifierService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public ClassifierService() : base(new StandardKernel(new DataAccessModule()).Get<IUnitOfWork>())
        {
        }
    }
}
