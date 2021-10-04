using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP4.Logic
{
    public interface ILogic<T,IdType>
    {
        List<T> GetAll();
        T GetOne(IdType id);
        void AddOne(T objectToAdd);
        void DeleteOne(T objectToDelete);
        void Update();
    }
}
