using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbAdvPrgAdv_Auftragsverwaltung.Model;
using Microsoft.EntityFrameworkCore;

namespace DbAdvPrgAdv_Auftragsverwaltung.Repository
{
    internal class GroupRepository : RepositoryBase<Group>
    {
        public override List<Group> GetAll()
        {
            using (var context = new OrderContext())
            {
                return context.Groups.Include("Articles").ToList();
            }
        }

        public override Group GetById(int ID)
        {
            using (var context = new OrderContext())
            {
                return context.Groups.FirstOrDefault(x => x.GroupID == ID);
            }
        }
        public Group GetByName(string name) {
            using (var context = new OrderContext()) {
                return context.Groups.FirstOrDefault(x => x.Name.Equals(name));
            }
        }
        public override List<Group> SearchByName(string name)
        {
            using (var context = new OrderContext())
            {
                return context.Groups.Where(x => x.Name.Contains(name)).ToList();
            }
        }
        public override void Add(Group entity)
        {
            using (var context = new OrderContext())
            {
                context.Groups.Add(entity);
                context.SaveChanges();
            }
        }

        public override void Update(Group entity)
        {
            using (var context = new OrderContext())
            {
                context.Groups.Update(entity);
                context.SaveChanges();
            }
        }
        public override void DeleteById(int id)
        {
            using (var context = new OrderContext())
            {
                context.Groups.Remove(GetById(id));
                context.SaveChanges();
            }
        }
    }
}
