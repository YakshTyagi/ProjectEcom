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
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserInterface repository;


        public UserController(UserInterface _repository)
        {
            repository = _repository;
        }
        [HttpGet]
        public ActionResult Get()
        {
            var response = repository.GetUser();
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
        public ActionResult Insert(UserTable model)
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
        public ActionResult<UserTable> GetByUserGuid(Guid id)
        {
            var response = repository.GetByUserGuid(id);
            if (response != null)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest("Record not found.");
            }
        }
        [HttpGet("{email}")]
        public ActionResult<UserTable> GetIdByEmail(string email)
        {
            var response = repository.GetIdByEmail(email);
            if (response != null)
            {
                return Ok(response.Id);
            }
            else
            {
                return BadRequest("Record not found.");
            }
        }
    }
}
        
        

       
    

