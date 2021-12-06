using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Net.Http;
using System.Net.Http.Json;
using Newtonsoft.Json;
using BackendEcom.Models;
using FrontendEcom.Models;
using FrontendEcom.HelperClass;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Http;


namespace FrontendEcom.Controllers
{

    public class RegisterController : Controller
    {
        Helper api = new Helper();
        HttpClient client;
        public async Task<IActionResult> Index()
        {
            List<UserTableData> userlist = new List<UserTableData>();
            client = api.Initial();
            HttpResponseMessage response = await client.GetAsync("api/User");
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                userlist = JsonConvert.DeserializeObject<List<UserTableData>>(result);
            }
            return View(userlist);
        }
        [HttpGet]
        //[Route("")]
        //[Route("Register")]
        //[Route("Register/RegisterUser")]
        public IActionResult RegisterUser()
        {
            return View();
        }
        [HttpPost]
        public IActionResult RegisterUser(UserTable user)
        {
            
            client = api.Initial();
            var postTask = client.PostAsJsonAsync<UserTable>("api/User/", user);
           // postTask.Wait();
            HttpResponseMessage result = postTask.Result;
            Guid MyId = ((BackendEcom.Models.UserTable)((System.Net.Http.Json.JsonContent)result.RequestMessage.Content).Value).Id;
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("AssignRole");
            }
            return View();
        }
        [HttpGet]
        //[Route("")]
        [Route("Register/LoginUser")]
        public IActionResult LoginUser()
        {
            return View();
        }
        [HttpPost]
        public IActionResult LoginUser(LoginData loginData)
        {
            return View();
        }



        [HttpGet]
        [Route("Register/AssignRole")]
        public ActionResult AssignRole(AssignRoleModel assignRoleModel)
        {
            
            ViewBag.RegisterType = new SelectList(
                                           new List<SelectListItem>
                                           {
                                        new SelectListItem { Text = "Seller", Value = "1" },
                                        new SelectListItem { Text = "Customer", Value = "2"}, //....
                                           }, "Value", "Text");


            return View();
        }

        [Route("Register/RegisterSeller")]
        public IActionResult RegisterSeller()
        {
            return View();
        }
        public IActionResult RegisterSeller(Seller seller)
        {

            client = api.Initial();
            var PostTask = client.PostAsJsonAsync<Seller>("api/Seller/Insert", seller);
            HttpResponseMessage result = PostTask.Result;
            seller.Sellerid = new Guid((string)JsonConvert.DeserializeObject(HttpContext.Session.GetString("UserId")));


            return RedirectToAction("LoginUser");
        }
        [Route("Register/RegisterCustomer")]
        public IActionResult RegisterCustomer()
        {
            return View();
        }
        public IActionResult RegisterCustomer(Customer customer)
        {

            client = api.Initial();
            var PostTask = client.PostAsJsonAsync<Customer>("api/Customer/Insert", customer);
            HttpResponseMessage result = PostTask.Result;
            customer.UserId = new Guid((string)JsonConvert.DeserializeObject(HttpContext.Session.GetString("UserId")));
            return RedirectToAction("LoginUser");
        }
    }
}





