using BusinessLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services.Interface
{
       public interface ICustomerInterface
       {
        Task<(bool status, GetAllCustResponse response)> GetAllCust();
        Task<(bool status, GetCustByIdCustResponse response)> GetCustById(int id);
        Task<(bool status, CreateCustResponse response)> CreateCust(CreateCustRequest request);
        Task<(bool status, UpdateCustResponse response)> UpdateCust(UpdateCustRequest request);
        Task<(bool status, DeleteCustResponse response)> DeleteCust(int id);
        Task<(bool status, GetjoinlistResponse response)> Getjoinlist();

       }
}
