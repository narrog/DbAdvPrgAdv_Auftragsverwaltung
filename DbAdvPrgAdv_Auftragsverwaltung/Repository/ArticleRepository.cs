﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbAdvPrgAdv_Auftragsverwaltung.Model;
using Microsoft.EntityFrameworkCore;

namespace DbAdvPrgAdv_Auftragsverwaltung.Repository
{
    internal class ArticleRepository : RepositoryBase<Article>
    {
        public override List<Article> GetAll()
        {
            using (var context = new OrderContext())
            {
                return context.Articles.Include("Group").Include("Positions").ToList();
            }
        }
        public override Article GetById(int id)
        {
            using (var context = new OrderContext())
            {
                return context.Articles.FirstOrDefault(x => x.ArticleID == id);
            }
        }
        public override List<Article> SearchByName(string name)
        {
            using (var context = new OrderContext())
            {
                return context.Articles.Where(x => x.Name.Contains(name)).ToList();
            }
        }
        public override void DeleteById(int id)
        {
            using (var context = new OrderContext())
            {
                context.Articles.Remove(GetById(id));
                context.SaveChanges();
            }
        }
    }
}