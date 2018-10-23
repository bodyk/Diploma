using System.Collections.Generic;
using Verbarium.BLL.Desktop.Interfaces;
using Verbarium.BLL.DTOs;
using Verbarium.BLL.Services;
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

        public bool AddClassifier(string name, int parentId, ref int classifierId, string description = "")
        {
            throw new System.NotImplementedException();
        }

        public bool AddWord(int wordId, List<ClassifierDto> classifiers)
        {
            throw new System.NotImplementedException();
        }

        public bool DeleteWordFromClassifier(int wordId, int classifierId)
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
    }
}
