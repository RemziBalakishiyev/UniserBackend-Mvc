using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Dtos
{
    public class ProductListDto
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
 
        public double Price { get; set; }
        public string StockInHand { get; set; }

        public string CategoryName { get; set; }
    }
}
