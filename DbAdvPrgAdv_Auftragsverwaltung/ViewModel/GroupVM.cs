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
        private readonly IGroupRepository _groupRep;

        public GroupVM(IGroupRepository grpRepo)
        {
            _groupRep = grpRepo;
        }
        public List<Group> GetGroups()
        {
            return _groupRep.GetAll();
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
    }
}
