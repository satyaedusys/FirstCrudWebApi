using BusinessLayer.DTOs;
using BusinessLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
 
namespace BusinessLayer.Mappers
{
    public class CustomerMapper
    {
        public static IEnumerable<CustomerModel> GetCustomerDTOToModelList(IEnumerable<CustomerDTO> source)
        {
            return source.Select(x => GetCustomerDTOToModel(x));
        }

        public static CustomerModel GetCustomerDTOToModel(CustomerDTO source)
        {
            return new CustomerModel()
            {
                CustomerID = source.CustomerID,
                CustomerName = source.CustomerName,
                Address = source.Address,
                City = source.City,
                Email = source.Email,
                Gender = source.Gender,
            };

        }


        public static IEnumerable<CustomerModel> GetjoinlistToModelList(IEnumerable<Getjoinlist> source)
        {
            return source.Select(x => GetjoinlistToModel(x));
        }

        public static CustomerModel GetjoinlistToModel(Getjoinlist source)
        {
            return new CustomerModel()
            {
                OrderId=source.OrderId,
                CustomerName = source.CustomerName,
                Address = source.Address,
                OrderNumber = source.OrderNumber,
                OrderDetials=source.OrderDetials     
            };

        }
    }
}
