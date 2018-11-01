using Ninject;
using System.Collections.Generic;
using System.Linq;
using Verbarium.BLL.Desktop.Interfaces;
using Verbarium.BLL.DTOs;
using Verbarium.BLL.Extensions.Mapper;
using Verbarium.BLL.Services;
using Verbarium.DAL.Infrastructure;
using Verbarium.DAL.Interfaces;

namespace Verbarium.BLL.Desktop.Services
{
    public class ClassifierService : ClassifierServiceCrud, IClassifierService
    {
        public List<ClassifierDto> GetAllClassifiers(int? rootId)
        {
            return Repository.Query
                .Where(cl => cl.Id == rootId)
                .Select(cl => cl.ToDto())
                .ToList();
        }

        public List<ClassifierDto> GetRootClassifiers()
        {
            return Repository.Entities
                .Where(cl => cl.ParentId == null)
                .Select(cl => cl.ToDto())
                .ToList();
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
            return Repository.Entities
                .Where(cl => cl.ParentId == classifId)
                .Select(cl => cl.ParentId)
                .FirstOrDefault() ?? -1;
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

        public bool IsWordInClassifier(int wordId, int classifiersId)
        {
            return Repository.Query.FirstOrDefault(cl => cl.Id == classifiersId)?.Words.Any(w => w.Id == wordId) ?? false;
        }

        public bool DeleteWordFromClassifier(int wordId, int classifierId)
        {
            Repository.Entities.FirstOrDefault(cl => cl.Id == classifierId)?.Words.RemoveAll(w => w.Id == wordId);
            return true;
        }

        public bool DeleteWordFromClassifier(int wordId, ClassifierDto dto)
        {
            return DeleteWordFromClassifier(wordId, dto.Id);
        }

        public bool NormalizeClassifiers()
        {
            foreach (var classifier in Repository.Query.Where(cl => cl.ParentId == null && cl.Words.Count == 0))
            {
                Delete(classifier.Id);
            }
            return true;
        }

        public bool DeleteClassifier(int classifierId)
        {
            Delete(classifierId);
            return true;
        }

        public void DeleteAllClassifiers()
        {
            foreach (var entity in UnitOfWork.Context.Classifiers)
                UnitOfWork.Context.Classifiers.Remove(entity);
            UnitOfWork.Context.SaveChanges();
        }

        public ClassifierService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public ClassifierService() : base(new StandardKernel(new DataAccessModule()).Get<IUnitOfWork>())
        {
        }
    }
}
