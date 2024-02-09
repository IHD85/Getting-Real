using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GettingReal
{
    internal class Overview
    {
        int OnOrder;
        int InStorage;
        int Available;
        int OrderNumber;
        int ProductNumber;

        public Overview(int onOrder, int inStorage, int available, int orderNumber, int productNumber)
        {
            OnOrder = onOrder;
            InStorage = inStorage;
            Available = available;
            OrderNumber = orderNumber;
            ProductNumber = productNumber;
        }
    }
}
