using DbAdvPrgAdv_Auftragsverwaltung.Model;
using DbAdvPrgAdv_Auftragsverwaltung.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbAdvPrgAdv_Auftragsverwaltung.ViewModel
{
    internal class TreeViewVM
    {
        private readonly ITreeViewRepository _treeViewRepo;
        public TreeViewVM(ITreeViewRepository treeRepo)
        {
            _treeViewRepo = treeRepo;
        }
        public List<Group> GetTreeView()
        {
            return _treeViewRepo.GetGroupTree();
        }
    }
}
