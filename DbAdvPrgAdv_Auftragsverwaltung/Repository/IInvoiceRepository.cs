using DbAdvPrgAdv_Auftragsverwaltung.Model;
using System;
using System.Collections.Generic;

namespace DbAdvPrgAdv_Auftragsverwaltung.Repository
{
    internal interface IInvoiceRepository
    {
        public List<Invoice> GetInvoices();
        public List<Invoice> GetInvoices(DateTime dateFrom, DateTime dateTo);
    }
}