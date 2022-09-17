using DbAdvPrgAdv_Auftragsverwaltung.Model;
using DbAdvPrgAdv_Auftragsverwaltung.Repository;
using Moq;

namespace DbAdvPrgAdv_Test
{
    public class Article_Test
    {
        /**** Methoden Tests ****/
        [Fact]
        public void CallGetAll() {
            var mock = new Mock<ArticleRepository>();
            mock.Setup(x => x.GetAll());
        }
        [Fact]
        public void CallGetById() {
            var mock = new Mock<ArticleRepository>();
            var article = new Article().ArticleID;
            mock.Setup(x => x.GetById(article));
        }
        [Fact]
        public void CallGetByName() {
            var mock = new Mock<ArticleRepository>();
            var article = new Article().Name;
            mock.Setup(x => x.SearchByName(article));
        }
        [Fact]
        public void CallAdd() {
            var mock = new Mock<ArticleRepository>();
            var article = new Article();
            mock.Setup(x => x.Add(article));
        }
        [Fact]
        public void CallUpdate() {
            var mock = new Mock<ArticleRepository>();
            var article = new Article();
            mock.Setup(x => x.Update(article));
        }
        [Fact]
        public void CallDelete() {
            var mock = new Mock<ArticleRepository>();
            var article = new Article().ArticleID;
            mock.Setup(x => x.DeleteById(article));
        }
    }
}