using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Model
{
    public class CustomerModel
    {
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public int OrderId { get; set; }
        public int OrderNumber { get; set; }
        public string OrderDetials { get; set; }
    }

    public class GetAllCustResponse : APIResponse
    { 
        public List<CustomerModel> CustomerList { get; set; }
    }
    public class GetAllCustRequest : APIRequest
    {
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }

    }

    public class GetCustByIdCustResponse : APIResponse
    {
        public CustomerModel Customer { get; set; }
    }

    public class CreateCustResponse : APIResponse
    {
        public int CustomerID { get; set; }

    }
    public class CreateCustRequest : APIRequest
    {
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public int OrderNumber { get; set; }
        public string OrderDetials { get; set; }
    }

    public class UpdateCustResponse : APIResponse
    {
    }
    public class UpdateCustRequest : APIRequest
    {
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
    }

    public class DeleteCustResponse : APIResponse
    {
        public int CustomerID { get; set; }
    }
    public class DeleteCustRequest : APIRequest
    {
        public int CustomerID { get; set; }

    }

    public class GetjoinlistResponse : APIResponse
    {
        public List<CustomerModel> CustomerList { get; set; }
    }

}
