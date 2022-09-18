using DbAdvPrgAdv_Auftragsverwaltung.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbAdvPrgAdv_Auftragsverwaltung.Repository
{
    internal class TreeViewRepository : ITreeViewRepository
    {
        public List<Group> GetGroupTree()
        {
            using (var context = new OrderContext())
            {
                return context.GroupTree();
            }
        }
    }
}
