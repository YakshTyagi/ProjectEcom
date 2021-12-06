using BackendEcom.IRepository;
using BackendEcom.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendEcom.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly CustomerInterface repository;
        public CustomerController(CustomerInterface _repository)
        {
            repository = _repository;
        }
        [HttpGet]
        public ActionResult Get()
        {
            var response = repository.GetCustomer();
            if (response != null)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest("Record not found.");
            }

        }
        [HttpPost]
        public ActionResult Insert(Customer model)
        {
            var response = repository.Insert(model);
            if (response == "User saved successfully.")
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response);
            }
        }
        [HttpGet("{id}")]
        public ActionResult<Customer> GetByCustomerGuid(Guid id)
        {
            var response = repository.GetByCustomerGuid(id);
            if (response != null)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest("Record not found.");
            }
        }
    }
}
