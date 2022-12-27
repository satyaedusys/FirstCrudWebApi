using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using System;
using BusinessLayer.Model;
using BusinessLayer.Services.Interface;

namespace FirstCrudWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerInterface _customerservice;
        public CustomerController(ICustomerInterface _customerservice, IConfiguration config)
        {
            this._customerservice = _customerservice;
        }

        [HttpPost("Create-customer")]
        public async Task<ActionResult<CreateCustResponse>> CreateCust([FromBody] CreateCustRequest request)
        {
            try
            {
                var result = await _customerservice.CreateCust(request);

                if (result.status)
                {
                    return Ok(result.response);
                }

            }
            catch (Exception)
            {
                return BadRequest();
            }
            return BadRequest();
        }

        [HttpGet("get-all-customer")]
        public async Task<ActionResult<GetAllCustResponse>> GetAllCust()
        {
            try
            {
                
                 var result = await _customerservice.GetAllCust();
                 if (result.status)
                 {
                   return Ok(result.response);
                 }
                
            }
            catch (Exception)
            {

                return BadRequest();
            }
            return BadRequest();
        }

        [HttpGet("get-cust-ById")]
        public async Task<ActionResult<GetCustByIdCustResponse>> GetCustById([FromQuery] int id)
        {
            try
            {
                var result=await _customerservice.GetCustById(id);
                if (result.status)
                {
                    return Ok(result.response);
                }
            }
            catch (Exception)
            {

                return BadRequest();
            }
            return BadRequest();
        }

        [HttpPost("Update-customer")]
        public async Task<ActionResult<UpdateCustResponse>> UpdateCust([FromBody] UpdateCustRequest request)
        {
            try
            {
                var result = await _customerservice.UpdateCust(request);
                if (result.status)
                {
                    return Ok(result.response);
                }
            }
            catch (Exception)
            {

                return BadRequest();
            }
            return BadRequest();    
        }

        [HttpPost("Delete-customer")]
        public async Task<ActionResult<DeleteCustResponse>> DeleteCust([FromQuery]int id)
        {
            try
            {
                var result = await _customerservice.DeleteCust(id);

                if (result.status)
                {
                    return Ok(result.response);
                }
            }
            catch (Exception)
            {

                return BadRequest();
            }
            return BadRequest();
        }

        [HttpGet("get-joinlist")]
        public async Task<ActionResult<GetjoinlistResponse>> Getjoinlist()
        {
            try
            {
                var result = await _customerservice.Getjoinlist();
                if (result.status)
                {
                    return Ok(result.response);
                }

            }
            catch (Exception)
            {

                return BadRequest();
            }
            return BadRequest();
        }

    }

}
