using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CutomerInfoCT_02.Repository;
using CutomerInfoCT_02.Model;

namespace CutomerInfoCT_02.BLL
{
   public class CustomerManager
    {
        CustomerRepository _customerRepository = new CustomerRepository();


        public bool Add(Customer customer)
        {
            return _customerRepository.Add(customer);
        }

        public bool IsCodeExists(string code)
        {
            return _customerRepository.IsCodeExists(code);
        }

        public bool IsContactExists(string contact)
        {
            return _customerRepository.IsContactExists(contact);
        }

        public List<Customer> Display()
        {
            return _customerRepository.Display();

        }

        public List<Customer> Search(string Code)
        {

            return _customerRepository.Search(Code);
        }

        public List<Customer> DistrictCombo()
        {
            return _customerRepository.DistrictCombo();

        }



    }
}
