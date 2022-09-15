using DbAdvPrgAdv_Auftragsverwaltung.Model;
using DbAdvPrgAdv_Auftragsverwaltung.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbAdvPrgAdv_Auftragsverwaltung.ViewModel
{
    internal class GroupVM
    {
        private readonly GroupRepository _groupRep;

        public GroupVM()
        {
            _groupRep = new GroupRepository();
        }
        public List<Group> GetGroups()
        {
            return _groupRep.GetAll();
        }
        public List<Group> SearchGroupByName(string name)
        {
            return _groupRep.SearchByName(name);
        }
        public Group GetGroupByID(int id) {
            return _groupRep.GetById(id);
        }
        public void AddGroup(Group group)
        {
            _groupRep.Add(group);
        }
        public void UpdateGroup(Group group)
        {
            _groupRep.Update(group);
        }
        public void DeleteGroupById(int id)
        {
            _groupRep.DeleteById(id);
        }

    }
}
