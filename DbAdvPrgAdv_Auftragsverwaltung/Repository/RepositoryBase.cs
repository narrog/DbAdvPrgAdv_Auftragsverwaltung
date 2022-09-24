using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbAdvPrgAdv_Auftragsverwaltung.Repository
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        public abstract List<T> GetAll();
        public abstract T GetById(int id);
        public abstract List<T> SearchByName(string name);
        public abstract void Add(T entity);
        public abstract void Update(T entity);
        public abstract void DeleteById(int id);
    }
}
