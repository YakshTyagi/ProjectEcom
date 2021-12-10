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
using Newtonsoft.Json.Linq;

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
        public async Task<IActionResult> RegisterUser(UserTable user)
        {
            HttpResponseMessage result;
            Guid user1 = new Guid();
            client = api.Initial();
            var postTask = client.PostAsJsonAsync<UserTable>("api/User/Insert", user);
            postTask.Wait();
            result = postTask.Result;
            if (result.IsSuccessStatusCode)
            {
                result = await client.GetAsync("api/User/GetIdByEmail/" + user.Email);


                if (result.IsSuccessStatusCode)
                {
                    var repo = result.Content.ReadAsStringAsync().Result;
                    user1 = JsonConvert.DeserializeObject<Guid>(repo);
                    HttpContext.Session.SetString("UserId", JsonConvert.SerializeObject(user1));
                    return RedirectToAction("AssignRole");
                }
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



            return View();
        }
        [HttpGet]
        [Route("Register/RegisterSeller")]
        public IActionResult RegisterSeller()
        {
            return View();
        }
        [HttpPost]
        public IActionResult RegisterSeller(Seller seller)
        {

            HttpResponseMessage response;
            client = api.Initial();
            Guid guid = new Guid();
            String myId = String.Empty;

            if (HttpContext.Session.GetString("UserId") != null)
            {
                myId = (string)JsonConvert.DeserializeObject(HttpContext.Session.GetString("UserId"));
                guid = Guid.Parse(myId);
                seller.Sellerid = guid;
                var PostTask = client.PostAsJsonAsync<Seller>("api/Seller/Insert", seller);
                response = PostTask.Result;
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("LoginUser");
                }
                else
                {
                    ViewBag.ErrorRegistrationFailed = " Registration as Seller Failed";
                    return View();
                }
            }
            else
            {
                ViewBag.ErrorSessionExpired = "Session Expired";
                return View();
            }

        }
        [HttpGet]
        [Route("Register/RegisterCustomer")]
        public IActionResult RegisterCustomer()
        {
            return View();
        }

        [HttpPost]
        public IActionResult RegisterCustomer(Customer customer)
        {

            HttpResponseMessage response;
            client = api.Initial();
            Guid guid = new Guid();
            String myId = String.Empty;

            if (HttpContext.Session.GetString("UserId") != null)
            {
                myId = (string)JsonConvert.DeserializeObject(HttpContext.Session.GetString("UserId"));
                guid = Guid.Parse(myId);
                customer.UserId = guid;
                var PostTask = client.PostAsJsonAsync<Customer>("api/Customer/Insert", customer);
                response = PostTask.Result;
                //    if (response.IsSuccessStatusCode)
                //    {
                //        return RedirectToAction("LoginUser");
                //    }
                //    else
                //    {
                //        ViewBag.ErrorRegistrationFailed = " Registration as Customer Failed";
                //        return View();
                //    }
                //}
                //else
                //{
                //    ViewBag.ErrorSessionExpired = "Session Expired";
                //    return View();
                //}

            }
            return RedirectToAction("LoginUser");
        }
    }
}





