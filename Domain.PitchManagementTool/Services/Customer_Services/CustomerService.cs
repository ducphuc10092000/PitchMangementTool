using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.PitchManagementTool.Services.Customer
{
    public class CustomerService
    {
        public CustomerService()
        {

        }

        public bool AddNewCustomer(CUSTOMER newCustomer)
        {
            bool success = false;
            if(newCustomer != null)
            {
                DataProvider.Ins.DB.CUSTOMERs.Add(newCustomer);
                DataProvider.Ins.DB.SaveChanges();
                success = true;
            }
            return success;
        }

        public bool EditCustomer()
        {
            return true;
        }

        public bool DeletedCustomer()
        {
            return true;
        }
    }
}
