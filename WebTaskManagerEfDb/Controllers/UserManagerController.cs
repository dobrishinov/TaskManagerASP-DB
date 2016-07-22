namespace WebTakManager.Controllers
{
    using DataAccess.Entity;
    using DataAccess.Repository;
    using System.Web.Mvc;
    using WebTaskManager.Models;

    public class UsersManagerController : Controller
    {
        public ActionResult Index()
        {
            if (AuthenticationManager.LoggedUser == null)
                return RedirectToAction("Login", "Home");

            UsersRepository usersRepository = new UsersRepository();
            ViewData["users"] = usersRepository.GetAll();

            return View();
        }
        [HttpGet]
        public ActionResult EditUser(int? id)
        {
            if (AuthenticationManager.LoggedUser == null)
                return RedirectToAction("Login", "Home");

            UsersRepository usersRepository = new UsersRepository();

            UserEntity user = null;
            if (id == null)
                user = new UserEntity();
            else
                user = usersRepository.GetById(id.Value);

            ViewData["user"] = user;

            return View();
        }
        [HttpPost]
        public ActionResult EditUser(UserEntity user)
        {
            if (AuthenticationManager.LoggedUser == null)
                return RedirectToAction("Login", "Home");

            UsersRepository usersRepository = new UsersRepository();
            usersRepository.Save(user);

            return RedirectToAction("Index", "UsersManager");
        }

        public ActionResult DeleteUser(int id)
        {
            if (AuthenticationManager.LoggedUser == null)
                return RedirectToAction("Login", "Home");

            UsersRepository usersRepository = new UsersRepository();
            UserEntity user = usersRepository.GetById(id);
            usersRepository.Delete(user);

            return RedirectToAction("Index", "UsersManager");
        }
    }
}