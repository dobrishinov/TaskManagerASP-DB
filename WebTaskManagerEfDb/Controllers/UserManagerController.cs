namespace WebTakManager.Controllers
{
    using DataAccess.Entity;
    using DataAccess.Repository;
    using System.Linq;
    using System.Web.Mvc;
    using WebTaskManager.Models;
    using WebTaskManagerEfDb.ViewModels.Users;
    public class UsersManagerController : Controller
    {
        public ActionResult Index()
        {
            if (AuthenticationManager.LoggedUser == null)
                return RedirectToAction("Login", "Home");

            UsersRepository repo = new UsersRepository();
            UsersListVM model = new UsersListVM() ;
            model.Items = repo.GetAll().ToList();


            return View(model);
        }
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (AuthenticationManager.LoggedUser == null)
                return RedirectToAction("Login", "Home");

            UsersRepository usersRepository = new UsersRepository();

            UserEntity user = null;
            if (id == null)
                user = new UserEntity();
            else
                user = usersRepository.GetById(id.Value);

            UsersEditVM model = new UsersEditVM();
            model.Id = user.Id;
            model.FirstName = user.FirstName;
            model.LastName = user.LastName;
            model.Username = user.Username;
            model.Password = user.Password;
            model.AdminStatus = user.AdminStatus;

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(UsersEditVM model)
        {
            if (AuthenticationManager.LoggedUser == null)
                return RedirectToAction("Login", "Home");

            UsersRepository usersRepository = new UsersRepository();
            UserEntity entity = new UserEntity();
            entity.Id = model.Id;
            entity.FirstName = model.FirstName;
            entity.LastName = model.LastName;
            entity.Username = model.Username;
            entity.Password = model.Password;
            entity.AdminStatus = model.AdminStatus;
            usersRepository.Save(entity);

            return RedirectToAction("Index", "UsersManager");
        }

        public ActionResult Delete(int id)
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