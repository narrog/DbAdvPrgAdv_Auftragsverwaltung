using DbAdvPrgAdv_Auftragsverwaltung.Model;
using DbAdvPrgAdv_Auftragsverwaltung.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbAdvPrgAdv_Auftragsverwaltung.ViewModel {
    internal class ArticleVM {
        private readonly IArticleRepository _articleRep;
        private readonly IGroupRepository _groupRep;

        public ArticleVM(IArticleRepository artRepo, IGroupRepository grpRepo) {
            _articleRep = artRepo;
            _groupRep = grpRepo;
        }
        public List<Group> GetGroups() {
            return _groupRep.GetAll();
        }
        public Group GetGroupByID(int id) {
            return _groupRep.GetById(id);
        }
        public Article GetArticleByID(int id) {
            return _articleRep.GetById(id);
        }
        public void AddArticle(Article article) {
            _articleRep.Add(article);
        }
        public void UpdateArticle(Article article) {
            _articleRep.Update(article);
        }
    }
}
