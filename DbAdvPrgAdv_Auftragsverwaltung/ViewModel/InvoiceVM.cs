using DbAdvPrgAdv_Auftragsverwaltung.Model;
using DbAdvPrgAdv_Auftragsverwaltung.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbAdvPrgAdv_Auftragsverwaltung.ViewModel
{
    internal class InvoiceVM
    {
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly IGroupRepository _groupRepository;
        private readonly IArticleRepository _articleRepository;
        public InvoiceVM(IInvoiceRepository invRepo, IGroupRepository grpRepo, IArticleRepository artRepo)
        {
            _invoiceRepository = invRepo;
            _groupRepository = grpRepo;
            _articleRepository = artRepo;
        }
        public List<Group> GetGroups()
        {
            return _groupRepository.GetAll();
        }
        public List<Article> GetArticles()
        {
            return _articleRepository.GetAll();
        }
        public List<Invoice> GetInvoices()
        {
            return _invoiceRepository.GetInvoices();
        }
        public List<Invoice> GetInvoicesByDates(DateTime dateFrom, DateTime dateTo)
        {
            return _invoiceRepository.GetInvoices(dateFrom, dateTo);
        }
    }
}
