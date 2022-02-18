using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace DbAdvPrgAdv_Auftragsverwaltung.Model
{
    public class Kunde
    {
        public int KundeID { get; set; }
        public string Name { get; set; }
        public string Vorname { get; set; }
        public string Strasse { get; set; }
        public string Email { get; set; }
        public string Webseite { get; set; }
        public string Passwort { get; set; }
        public int OrtID { get; set; }
        public virtual Ort Ort { get; set; }

        public virtual ICollection<Auftrag> Auftraege { get; set; }
        public Kunde LoadOne(int id)
        {
            using (var context = new OrderContext())
            {
                return context.Kunden
                    .Include(x => x.Auftraege)
                    .Include(x => x.Ort)
                    .FirstOrDefault(x => x.KundeID == id);
            }
        }
    }
}
