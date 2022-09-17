using DbAdvPrgAdv_Auftragsverwaltung.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbAdvPrgAdv_Auftragsverwaltung.Repository
{
    public interface IYoyRepository
    {
        public List<Yoy> GetSoldArticles();
        public List<Yoy> GetArticles();
        public List<Yoy> GetSumYoy();
        public List<YoyCustomer> GetSumCustomers();
        public List<Yoy> GetSumArticles();
    }
}
