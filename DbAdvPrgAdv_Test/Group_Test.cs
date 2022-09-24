using DbAdvPrgAdv_Auftragsverwaltung.Model;
using DbAdvPrgAdv_Auftragsverwaltung.Repository;
using Moq;

namespace DbAdvPrgAdv_Test
{
    public class Group_Test
    {
        /**** Methoden Tests ****/
        [Fact]
        public void CallGetAll() {
            var mock = new Mock<GroupRepository>();
            mock.Setup(x => x.GetAll());
        }
        [Fact]
        public void CallGetById() {
            var mock = new Mock<GroupRepository>();
            var group = new Group().GroupID;
            mock.Setup(x => x.GetById(group));
        }
        [Fact]
        public void CallGetByName() {
            var mock = new Mock<GroupRepository>();
            var group = new Group().Name;
            mock.Setup(x => x.SearchByName(group));
        }
        [Fact]
        public void CallAdd() {
            var mock = new Mock<GroupRepository>();
            var group = new Group();
            mock.Setup(x => x.Add(group));
        }
        [Fact]
        public void CallUpdate() {
            var mock = new Mock<GroupRepository>();
            var group = new Group();
            mock.Setup(x => x.Update(group));
        }
        [Fact]
        public void CallDelete() {
            var mock = new Mock<GroupRepository>();
            var group = new Group().GroupID;
            mock.Setup(x => x.DeleteById(group));
        }
    }
}