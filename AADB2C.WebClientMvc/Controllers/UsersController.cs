using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace AADB2C.WebClientMvc.Controllers
{
    [Authorize]
    public class UsersController : Controller
    {
        private static string serviceUrl = ConfigurationManager.AppSettings["api:OrdersApiUrl"];

        // GET: Users
        public async Task<ActionResult> Index()
        {
            try
            {

                var bootstrapContext = ClaimsPrincipal.Current.Identities.First().BootstrapContext as System.IdentityModel.Tokens.BootstrapContext;

                HttpClient client = new HttpClient();

                client.BaseAddress = new Uri(serviceUrl);

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", bootstrapContext.Token);
                
                HttpResponseMessage response = await client.GetAsync("api/User/Get?UserName=Me&password=");

                if (response.IsSuccessStatusCode)
                {

                    var user = await response.Content.ReadAsAsync<UserModel>();

                    return View(new List<UserModel> { user });
                }
                else
                {
                    // If the call failed with access denied, show the user an error indicating they might need to sign-in again.
                    if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                    {
                        return new RedirectResult("/Error?message=Error: " + response.ReasonPhrase + " You might need to sign in again.");
                    }
                }

                return new RedirectResult("/Error?message=An Error Occurred Reading Users List: " + response.StatusCode);
            }
            catch (Exception ex)
            {
                return new RedirectResult("/Error?message=An Error Occurred Reading Users List: " + ex.Message);
            }
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(UserModel user)
        {

            try
            {
                var bootstrapContext = ClaimsPrincipal.Current.Identities.First().BootstrapContext as System.IdentityModel.Tokens.BootstrapContext;

                HttpClient client = new HttpClient();

                client.BaseAddress = new Uri(serviceUrl);

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", bootstrapContext.Token);

                HttpResponseMessage response = await client.PostAsJsonAsync("api/User/Register", user);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    // If the call failed with access denied, show the user an error indicating they might need to sign-in again.
                    if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                    {
                        return new RedirectResult("/Error?message=Error: " + response.ReasonPhrase + " You might need to sign in again.");
                    }
                }

                return new RedirectResult("/Error?message=An Error Occurred Creating Order: " + response.StatusCode);
            }
            catch (Exception ex)
            {
                return new RedirectResult("/Error?message=An Error Occurred Creating Order: " + ex.Message);
            }

        }

    }

    public class UserModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}