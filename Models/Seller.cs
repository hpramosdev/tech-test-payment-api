using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tech_test_payment_api.Models
{
    public class Seller
    {
        public Guid Id { get; private set; }
        public string Cpf { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Phone { get; private set; }

        public Seller(string cpf, string name, string email, string phone)
        {
            Id = Guid.NewGuid();
            Cpf = cpf;
            Name = name;
            Email = email;
            Phone = phone;
        }

        public void Update(Seller seller)
        {
            Cpf = seller.Cpf;
            Name = seller.Name;
            Email = seller.Email;
            Phone = seller.Phone;
        }
    }
}