using DbAdvPrgAdv_Auftragsverwaltung.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbAdvPrgAdv_Auftragsverwaltung.Repository
{
    internal class PositionRepository : RepositoryBase<Position>, IPositionRepository
    {
        private readonly OrderContext _context = new OrderContext();
        public override void Add(Position entity)
        {
            using (_context)
            {
                entity.Order = null;
                entity.Article = null;
                _context.Add(entity);
                _context.SaveChanges();
            }
        }

        public void DeleteByCombinedId(int orderId, int articleId)
        {
            using (_context)
            {
                _context.Remove(_context.Positions.FirstOrDefault(x => x.OrderID == orderId && x.ArticleID == articleId));
                _context.SaveChanges();
            }
        }

        public override void DeleteById(int id)
        {
            using (_context)
            {
                _context.Remove(id);
                _context.SaveChanges();
            }
        }

        public override List<Position> GetAll()
        {
            using (_context)
            {
                return _context.Positions.ToList();
            }
        }

        public Position GetByCombinedId(int orderId, int articleId)
        {
            using (_context)
            {
                return _context.Positions.FirstOrDefault(x => x.OrderID == orderId && x.ArticleID == articleId);
            }
        }

        public override Position GetById(int id)
        {
            throw new NotImplementedException();
        }

        public override List<Position> SearchByName(string name)
        {
            throw new NotImplementedException();
        }

        public override void Update(Position entity)
        {
            throw new NotImplementedException();
        }
    }
}
