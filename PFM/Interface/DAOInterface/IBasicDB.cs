using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PFM.Interface.DAOInterface
{
    public interface IBasicDB<T> where T : IPoco
    {
        T GetById(int id);
        IList<T> GetAll();
        void Add(T t);
        void Remove(T t);
        void Update(T t);

    }
}
