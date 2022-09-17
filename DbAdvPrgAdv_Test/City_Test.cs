using DbAdvPrgAdv_Auftragsverwaltung.Model;
using DbAdvPrgAdv_Auftragsverwaltung.Repository;
using Moq;

namespace DbAdvPrgAdv_Test
{
    public class City_Test
    {
        /**** Methoden Tests ****/
        [Fact]
        public void CallGetAll() {
            var mock = new Mock<CityRepository>();
            mock.Setup(x => x.GetAll());
        }
        [Fact]
        public void CallGetById() {
            var mock = new Mock<CityRepository>();
            var city = new City().CityID;
            mock.Setup(x => x.GetById(city));
        }
        [Fact]
        public void CallGetByName() {
            var mock = new Mock<CityRepository>();
            var city = new City().CityName;
            mock.Setup(x => x.SearchByName(city));
        }
        [Fact]
        public void CallAdd() {
            var mock = new Mock<CityRepository>();
            var city = new City();
            mock.Setup(x => x.Add(city));
        }
        [Fact]
        public void CallUpdate() {
            var mock = new Mock<CityRepository>();
            var city = new City();
            mock.Setup(x => x.Update(city));
        }
        [Fact]
        public void CallDelete() {
            var mock = new Mock<CityRepository>();
            var city = new City().CityID;
            mock.Setup(x => x.DeleteById(city));
        }
    }
}