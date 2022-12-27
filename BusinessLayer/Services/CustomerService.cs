using BusinessLayer.DTOs;
using BusinessLayer.Mappers;
using BusinessLayer.Model;
using BusinessLayer.Services.Interface;
using Dapper;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public class CustomerService : ICustomerInterface
    {
        private readonly string _connectionString;
        public CustomerService(IConfiguration config)
        {
            _connectionString = config.GetConnectionString("Appcon");
        }
        public async Task<(bool status, CreateCustResponse response)> CreateCust(CreateCustRequest request)
        {
            CreateCustResponse Response = new CreateCustResponse();

            try
            {
                using var connection = new MySqlConnection(_connectionString);
                connection.Open();

                var p = new DynamicParameters();

                p.Add("CustomerName", request.CustomerName);
                p.Add("Address", request.Address);
                p.Add("City", request.City);
                p.Add("Email", request.Email);
                p.Add("Gender", request.Gender);
                p.Add("OrderNumber", request.OrderNumber);
                p.Add("OrderDetials", request.OrderDetials);

                var result = await Task.Run(() => connection.Execute("Create_Customer", p, commandType: CommandType.StoredProcedure));

                if (result == 0)
                {
                    return (false, Response);
                }
                return (true, Response);

            }
            catch (Exception)
            {
                return (false, Response);
            }
        }

        public async Task<(bool status, DeleteCustResponse response)> DeleteCust(int id)
        {
            DeleteCustResponse response = new();
            try
            {
                using var connection = new MySqlConnection(_connectionString);
                DynamicParameters p = new DynamicParameters();
                p.Add("id", id);
                var result = await Task.Run(() => connection.Execute("Delete_Customer", p, commandType: CommandType.StoredProcedure));

                if (result == 0)
                {
                    return (false, response);
                }
                return (true, response);

            }
            catch (Exception)
            {

                return (false, response);
            }
        }

        public async Task<(bool status, GetAllCustResponse response)> GetAllCust()
        {
            GetAllCustResponse response = new();
            {
                try
                {
                    using var connection = new MySqlConnection(_connectionString);
                    var result = await Task.Run(() => connection.Query<CustomerDTO>("GetAll_Customer", commandType: CommandType.StoredProcedure).ToList());
                    response.CustomerList = CustomerMapper.GetCustomerDTOToModelList(result).ToList();
                    if (result != null)
                    {
                        return (true, response);
                    }
                    return (false, response);
                }
                catch (Exception)
                {

                    return (false, response);
                }

            }
        }

        public async Task<(bool status, GetCustByIdCustResponse response)> GetCustById(int id)
        {
            GetCustByIdCustResponse response = new();
            {
                try
                {
                    using var connection = new MySqlConnection(_connectionString);
                    var p = new DynamicParameters();

                    p.Add("id", id);
                    var result = await Task.Run(() => connection.QueryFirstOrDefault<CustomerModel>("Get_CustById", p, commandType: CommandType.StoredProcedure));
                    if (result != null)
                    {
                        response.Customer = result;
                        return (true, response);
                    }
                }
                catch (Exception)
                {
                    return (false, response);

                }
                return (false, response);
            }
        }

        public async Task<(bool status, UpdateCustResponse response)> UpdateCust(UpdateCustRequest request)
        {
            UpdateCustResponse response = new();
            try
            {
                using var connecton = new MySqlConnection(_connectionString);
                var p = new DynamicParameters();
                p.Add("Id", request.CustomerID);
                p.Add("CustomerName", request.CustomerName);
                p.Add("Address", request.Address);
                p.Add("City", request.City);
                p.Add("Email", request.Email);
                p.Add("Gender", request.Gender);

                var result = await Task.Run(() => connecton.Execute("Update_Customer", p, commandType: CommandType.StoredProcedure));
                if (result == 0)
                {
                    return (false, response);
                }
                return (true, response);
            }
            catch (Exception)
            {

                return ((false, response));
            }

        }

        public async Task<(bool status, GetjoinlistResponse response)> Getjoinlist()
        {
            GetjoinlistResponse response = new();
            {
                try
                {
                    using var connection = new MySqlConnection(_connectionString);
                    var result = await Task.Run(() => connection.Query<Getjoinlist>("Get_joinlist", commandType: CommandType.StoredProcedure).ToList());
                    response.CustomerList = CustomerMapper.GetjoinlistToModelList(result).ToList();
                    if (result != null)
                    {
                        return (true, response);
                    }
                    return (false, response);
                }
                catch (Exception)
                {

                    return (false, response);
                }

            }
        }

    }

}

