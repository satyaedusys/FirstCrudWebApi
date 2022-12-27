using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.DTOs
{
    public class CustomerDTO
    {
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
    }

    //add another DTO class.
    public class Getjoinlist
    {
        public int OrderId { get; set; }
        public string CustomerName { get; set; }
        public string Address { get; set; }
        public int OrderNumber { get; set; }
        public string OrderDetials { get; set; }
    }
}
