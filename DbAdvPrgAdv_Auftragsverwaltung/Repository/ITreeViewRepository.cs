using DbAdvPrgAdv_Auftragsverwaltung.Model;
using System.Collections.Generic;

namespace DbAdvPrgAdv_Auftragsverwaltung.Repository
{
    internal interface ITreeViewRepository
    {
        public List<Group> GetGroupTree();
    }
}