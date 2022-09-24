using DbAdvPrgAdv_Auftragsverwaltung.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbAdvPrgAdv_Auftragsverwaltung.Repository
{
    interface IGroupRepository
    {
        public List<Group> GetAll();
        public Group GetById(int id);
        public List<Group> SearchByName(string name);
        public void Add(Group entity);
        public void Update(Group entity);
        public void DeleteById(int id);
    }
}
