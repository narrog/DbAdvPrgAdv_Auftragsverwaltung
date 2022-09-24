using FluentAssertions;
using DbAdvPrgAdv_Auftragsverwaltung.Model;
using DbAdvPrgAdv_Auftragsverwaltung.Repository;
using Moq;

namespace DbAdvPrgAdv_Test
{
    public class Customer_Test
    {
        ///**** TESTS REGEX MAIL PASSED ****/
        [Fact]
        public void AddValidMail1_Test()
        {
            var customer = new Customer();
            var email = "hans.muster@gmail.com";

            var output = customer.RegEx_Mail(email);

            output.Should().BeTrue();

        }
        [Fact]
        public void RegExMail_valid2_returnTrue()
        {
            var customer = new Customer();
            var email = "hansmuster@gmail.com";

            var output = customer.RegEx_Mail(email);

            output.Should().BeTrue();
        }


        /**** TESTS REGEX MAIL FAIL ****/
        [Fact]
        public void RegExMail_invalid1_returnFalse()
        {
            var customer = new Customer();
            var email = "hansmuster@gmail";

            var output = customer.RegEx_Mail(email);

            output.Should().BeFalse();
        }
        [Fact]
        public void RegExMail_invalid2_returnFalse()
        {
            var customer = new Customer();
            var email = "hansmuster@";

            var output = customer.RegEx_Mail(email);

            output.Should().BeFalse();
        }
        [Fact]
        public void RegExMail_invalid3_returnFalse()
        {
            var customer = new Customer();
            var email = "@gmail.com";

            var output = customer.RegEx_Mail(email);

            output.Should().BeFalse();
        }


        /**** TESTS REGEX WEB PASSED ****/
        [Fact]
        public void RegExWeb_HTTPS_ReturnTrue()
        {
            var customer = new Customer();
            var web = "https://www.google.ch";

            var output = customer.RegEx_Web(web);

            output.Should().BeTrue();
        }

        [Fact]
        public void RegExWeb_HTTP_ReturnTrue()
        {
            var customer = new Customer();
            var web = "http://www.google.ch";

            var output = customer.RegEx_Web(web);

            output.Should().BeTrue();
        }
        [Fact]
        public void RegExWeb_WWW_ReturnTrue()
        {
            var customer = new Customer();
            var web = "www.google.ch";

            var output = customer.RegEx_Web(web);

            output.Should().BeTrue();
        }
        [Fact]
        public void RegExWeb_web_ReturnTrue()
        {
            var customer = new Customer();
            var web = "google.ch";

            var output = customer.RegEx_Web(web);

            output.Should().BeTrue();
        }
        [Fact]
        public void RegExWeb_webWithParam_ReturnTrue()
        {
            var customer = new Customer();
            var web = "https://policies.google.com/technologies/voice?hl=de&gl=ch";

            var output = customer.RegEx_Web(web);

            output.Should().BeTrue();
        }

        /**** TESTS REGEX WEB FAIL ****/
        //[Fact]
        //public void RegExWeb_webInvalid1_ReturnFalse()
        //{
        //    var customer = new Customer();
        //    var web = ".google.ch";

        //    var output = customer.RegEx_Web(web);

        //    output.Should().BeFalse();
        //}
        [Fact]
        public void RegExWeb_webInvalid2_ReturnFalse()
        {
            var customer = new Customer();
            var web = "google123";

            var output = customer.RegEx_Web(web);

            output.Should().BeFalse();
        }

        /**** TESTS REGEX PASSWORD PASSED ****/
        [Fact]
        public void RegExPassword_passwordValid_ReturnTrue()
        {
            var customer = new Customer();
            var password = "Muster12!";

            var output = customer.RegEx_Password(password);

            output.Should().BeTrue();
        }

        /**** TESTS REGEX PASSWORD FAIL ****/
        [Fact]
        public void RegExPassword_passwordInvalidCount_ReturnFalse()
        {
            var customer = new Customer();
            var password = "muster12";

            var output = customer.RegEx_Password(password);

            output.Should().BeFalse();
        }
        [Fact]
        public void RegExPassword_passwordInvalidCapital_ReturnFalse() {
            var customer = new Customer();
            var password = "muster12!";

            var output = customer.RegEx_Password(password);

            output.Should().BeFalse();
        }
        [Fact]
        public void RegExPassword_passwordInvalidDigit_ReturnFalse()
        {
            var customer = new Customer();
            var password = "muster!!!";

            var output = customer.RegEx_Password(password);

            output.Should().BeFalse();
        }
        [Fact]
        public void RegExPassword_passwordInvalidSpecial_ReturnFalse()
        {
            var customer = new Customer();
            var password = "muster123";

            var output = customer.RegEx_Password(password);

            output.Should().BeFalse();
        }
        [Fact]
        public void RegExPassword_passwordInvalidLetter_ReturnFalse()
        {
            var customer = new Customer();
            var password = "12345!!!";

            var output = customer.RegEx_Password(password);

            output.Should().BeFalse();
        }

        /**** Methoden Tests ****/
        [Fact]
        public void CallGetAll() {
            var mock = new Mock<CustomerRepository>();
            mock.Setup(c => c.GetAll());
        }
        [Fact]
        public void CallGetById() {
            var mock = new Mock<CustomerRepository>();
            var customer = new Customer().CustomerID;
            mock.Setup(c => c.GetById(customer));
        }
        [Fact]
        public void CallGetByName() {
            var mock = new Mock<CustomerRepository>();
            var customer = new Customer().Name;
            mock.Setup(c => c.SearchByName(customer));
        }
        [Fact]
        public void CallAdd() {
            var mock = new Mock<CustomerRepository>();
            var customer = new Customer();
            mock.Setup(c => c.Add(customer));
        }
        [Fact]
        public void CallUpdate() {
            var mock = new Mock<CustomerRepository>();
            var customer = new Customer();
            mock.Setup(c => c.Update(customer));
        }
        [Fact]
        public void CallDelete() {
            var mock = new Mock<CustomerRepository>();
            var customer = new Customer().CustomerID;
            mock.Setup(c => c.DeleteById(customer));
        }
    }
}