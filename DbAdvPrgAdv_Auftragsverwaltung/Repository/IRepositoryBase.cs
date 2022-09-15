using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbAdvPrgAdv_Auftragsverwaltung.Repository
{
    internal interface IRepositoryBase<T> where T : class
    {
        public List<T> GetAll();
        public T GetById(int id);
        public List<T> SearchByName(string name);
        public void DeleteById(int id);
    }
}
