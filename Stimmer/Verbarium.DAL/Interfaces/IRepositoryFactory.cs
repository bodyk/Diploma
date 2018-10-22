using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verbarium.DAL.Context;

namespace Verbarium.DAL.Interfaces
{
    public interface IRepositoryFactory
    {
        IGenericRepository<T> CreateRepository<T>(VerbariumContext context) where T : class;
    }
}
