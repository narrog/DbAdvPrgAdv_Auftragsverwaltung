using DbAdvPrgAdv_Auftragsverwaltung.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbAdvPrgAdv_Auftragsverwaltung.Repository
{
    interface ICityRepository
    {
        public List<City> GetAll();
        public City GetById(int id);
        public List<City> SearchByName(string name);
        public City GetByPLZ(int plz);
        public void Add(City entity);
        public void Update(City entity);
        public void DeleteById(int id);
    }
}
