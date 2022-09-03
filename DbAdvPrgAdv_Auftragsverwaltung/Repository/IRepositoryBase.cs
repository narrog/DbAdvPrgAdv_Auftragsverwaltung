using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbAdvPrgAdv_Auftragsverwaltung.Repository
{
    internal interface IRepositoryBase<T> where T : class
    {
        public T GetById(int ID);
        public List<T> GetAll();
    }
}
