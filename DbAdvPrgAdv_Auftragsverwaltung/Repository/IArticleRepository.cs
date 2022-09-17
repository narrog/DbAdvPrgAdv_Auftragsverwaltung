using DbAdvPrgAdv_Auftragsverwaltung.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbAdvPrgAdv_Auftragsverwaltung.Repository
{
    internal interface IArticleRepository
    {
        public abstract List<Article> GetAll();
        public abstract Article GetById(int id);
        public abstract List<Article> SearchByName(string name);
        public abstract void Add(Article entity);
        public abstract void Update(Article entity);
        public abstract void DeleteById(int id);
    }
}
