using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Student_Task.Data;
using Student_Task.Functions;
using Student_Task.Models;

namespace Student_Task.Controllers
{
    public class LoginController : Controller
    {
        // GET: LoginController
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Index(LoginModel user)
        {
            var hashpassword = new Authentication();

            LoginDataAccessLayer loginDataAccessLayer = new LoginDataAccessLayer();

            if (ModelState.IsValid)
            {
                string passwordHash = hashpassword.MD5Hash(user.Password);

                LoginModel? loginUser = loginDataAccessLayer.CheckLogin(user.LoginId, user.Password);

                if (loginUser != null)
                {
                    HttpContext.Session.SetString("Id", loginUser.LoginId);
                    HttpContext.Session.SetString("Name", loginUser.UserName);
                    HttpContext.Session.SetString("Email", loginUser.Email);
                    HttpContext.Session.SetString("Role", loginUser.Role);

                    return RedirectToAction("Index", "Student");
                }
            }

            return View("Index");
        }
    }
}
