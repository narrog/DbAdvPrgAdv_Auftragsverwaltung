using DbAdvPrgAdv_Auftragsverwaltung.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbAdvPrgAdv_Auftragsverwaltung.Repository
{
    internal interface IPositionRepository
    {
        public List<Position> GetAll();
        public Position GetById(int id);
        public Position GetByCombinedId(int orderId, int articleId);
        public List<Position> SearchByName(string name);
        public void Add(Position entity);
        public void Update(Position entity);
        public void DeleteById(int id);
        public void DeleteByCombinedId(int orderId,int articleId);
    }
}
