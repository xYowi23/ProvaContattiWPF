using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Lez04_Contatti.Models.DAL
{
    internal interface IDao<T>
    {
        List<T> GetAll();
        T? GetById(int id);
        bool Insert(T t);
    }
}
