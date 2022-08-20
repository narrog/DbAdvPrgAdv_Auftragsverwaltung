using FluentAssertions;
using Xunit;
using DbAdvPrgAdv_Auftragsverwaltung;

namespace DbAdvPrgAdv_Auftragsverwaltung.Testing
{
    public class EditCustomer_Test
    {
        [Fact]
        public void RegExMail_valid1_returnTrue()
        {
            var customer = new EditCustomer(); 
            var email = "hans.muster@gmail.com";

            var output = customer.RegEx_Mail(email);

            output.Should().BeSameAs(true);
        }
    }
}