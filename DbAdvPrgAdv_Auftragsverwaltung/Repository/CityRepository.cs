using DbAdvPrgAdv_Auftragsverwaltung.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbAdvPrgAdv_Auftragsverwaltung.Repository
{
    internal class CityRepository : RepositoryBase<City>
    {
        public override List<City> GetAll()
        {
            using (var context = new OrderContext())
            {
                return context.Cities.ToList();
            }
        }

        public override City GetById(int ID)
        {
            using (var context = new OrderContext())
            {
                return context.Cities.FirstOrDefault(x => x.CityID == ID);
            }
        }
        public City GetByPLZ(int plz)
        {
            using (var context = new OrderContext())
            {
                return context.Cities.FirstOrDefault(x =>x.PLZ == plz);
            }
        }
        public override List<City> SearchByName(string name)
        {
            using (var context = new OrderContext())
            {
                return context.Cities.Where(x => x.CityName.Contains(name)).ToList();
            }
        }
        public override void Add(City entity)
        {
            using (var context = new OrderContext())
            {
                context.Cities.Add(entity);
                context.SaveChanges();
            }
        }

        public override void Update(City entity)
        {
            using (var context = new OrderContext())
            {
                context.Cities.Update(entity);
                context.SaveChanges();
            }
        }
        public override void DeleteById(int id)
        {
            using (var context = new OrderContext())
            {
                context.Cities.Remove(GetById(id));
                context.SaveChanges();
            }
        }
    }
}
