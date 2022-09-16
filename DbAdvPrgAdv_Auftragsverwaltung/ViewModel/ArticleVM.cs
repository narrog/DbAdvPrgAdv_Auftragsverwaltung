using DbAdvPrgAdv_Auftragsverwaltung.Model;
using DbAdvPrgAdv_Auftragsverwaltung.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbAdvPrgAdv_Auftragsverwaltung.ViewModel {
    internal class ArticleVM {
        private readonly ArticleRepository _articleRep;
        private readonly GroupRepository _groupRep;

        public ArticleVM() {
            _articleRep = new ArticleRepository();
            _groupRep = new GroupRepository();
        }
        public List<Group> GetGroups() {
            return _groupRep.GetAll();
        }
        public Group GetGroupByID(int id) {
            return _groupRep.GetById(id);
        }
        public Group GetGroupByName(string name) {
            return _groupRep.GetByName(name);
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
