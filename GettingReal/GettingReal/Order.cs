using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GettingReal
{
    enum Status
    {
        NotStarted,
        BeingFetched,
        Logo,
        Bagging,
        Packaging,
        Ready
    }

    internal class Order
    {
        int OrderNumber { get;  }

        int accountNumber;

        Employee Employee { get; set; }

        string Comment { get; set; }
        string poNumber;

        DateTime DateCreated;
        DateTime DateUpdated { get; set; }

        string customerInformation;
        List<Product> products;
        Status status;

        public Order(int orderNumber, int accountNumber, Employee employee, string comment,
                     string poNumber, DateTime date, string customerInformatoion, List<Product> products,
                     Status status)
        {
            OrderNumber = orderNumber;
            this.accountNumber = accountNumber;
            Employee = employee;
            Comment = comment;
            this.poNumber = poNumber;
            DateCreated = date;
            DateUpdated = date;
            customerInformation = customerInformatoion;
            this.products = products;
            this.status = status;
        }


    }
}
