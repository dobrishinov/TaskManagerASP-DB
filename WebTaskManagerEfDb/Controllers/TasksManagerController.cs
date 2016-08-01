namespace WebTaskManager.Controllers
{
    using DataAccess.Repository;
    using System.Web.Mvc;
    using Models;
    using DataAccess.Entity;
    using WebTaskManagerEfDb.ViewModels.Users;
    using System.Linq;
    using WebTaskManagerEfDb.ViewModels.Tasks;
    public class TasksManagerController : Controller
    {
        public ActionResult Index()
        {
            if (AuthenticationManager.LoggedUser == null)
                return RedirectToAction("Login", "Home");

            TasksRepository TasksRepository = new TasksRepository();
            TasksListVM model = new TasksListVM();
            model.Items = TasksRepository.GetAll(t => t.CreatorId == AuthenticationManager.LoggedUser.Id || t.ResponsibleUsers == AuthenticationManager.LoggedUser.Id).ToList();

            return View(model);
        }
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (AuthenticationManager.LoggedUser == null)
                return RedirectToAction("Login", "Home");

            TasksRepository tasksRepository = new TasksRepository();

            TaskEntity task = null;
            if (id == null)
                task = new TaskEntity();
            else
                task = tasksRepository.GetById(id.Value);

            TasksEditVM model = new TasksEditVM();
            model.Id = task.Id;
            model.CreatorId = task.CreatorId;
            model.ResponsibleUsers = task.ResponsibleUsers;
            model.Title = task.Title;
            model.Content = task.Content;
            model.Creator = task.Creator;

            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(TasksEditVM model)
        {
            if (AuthenticationManager.LoggedUser == null)
                return RedirectToAction("Login", "Home");

            TasksRepository tasksRepository = new TasksRepository();
            TaskEntity entity = new TaskEntity();
            entity.Id = model.Id;
            entity.CreatorId = model.CreatorId;
            entity.ResponsibleUsers = model.ResponsibleUsers;
            entity.Title = model.Title;
            entity.Content = model.Content;
            entity.Creator = model.Creator;

            tasksRepository.Save(entity);

            return RedirectToAction("Index", "TasksManager");
        }

        public ActionResult Delete(int id)
        {
            if (AuthenticationManager.LoggedUser == null)
                return RedirectToAction("Login", "Home");

            TasksRepository tasksRepository = new TasksRepository();
            TaskEntity user = tasksRepository.GetById(id);
            tasksRepository.Delete(user);

            return RedirectToAction("Index", "TasksManager");
        }
    }
}