namespace WebTaskManager.Controllers
{
    using DataAccess.Repository;
    using System.Web.Mvc;
    using Models;
    using DataAccess.Entity;

    public class TasksManagerController : Controller
    {
        public ActionResult Index()
        {
            if (AuthenticationManager.LoggedUser == null)
                return RedirectToAction("Login", "Home");

            TasksRepository TasksRepository = new TasksRepository();
            ViewData["tasks"] = TasksRepository.GetAll(t => t.CreatorId == AuthenticationManager.LoggedUser.Id || t.ResponsibleUsers == AuthenticationManager.LoggedUser.Id);

            return View();
        }
        [HttpGet]
        public ActionResult EditTask(int? id)
        {
            if (AuthenticationManager.LoggedUser == null)
                return RedirectToAction("Login", "Home");

            TasksRepository tasksRepository = new TasksRepository();

            TaskEntity task = null;
            if (id == null)
                task = new TaskEntity();
            else
                task = tasksRepository.GetById(id.Value);

            ViewData["task"] = task;

            return View();
        }
        [HttpPost]
        public ActionResult EditTask(TaskEntity task)
        {
            if (AuthenticationManager.LoggedUser == null)
                return RedirectToAction("Login", "Home");

            TasksRepository tasksRepository = new TasksRepository();
            tasksRepository.Save(task);

            return RedirectToAction("Index", "TasksManager");
        }

        public ActionResult DeleteTask(int id)
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