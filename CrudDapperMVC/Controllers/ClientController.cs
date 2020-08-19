using CrudDapperMVC.Domain.Entities;
using CrudDapperMVC.Service.Interface;
using System.Collections.Generic;
using System.Web.Mvc;

namespace CrudDapperMVC.Controllers
{
    public class ClientController : Controller
    {
        protected readonly IClientService _service;

        public ClientController(IClientService service)
        {
            _service = service;
        }

        // GET: Client
        public ActionResult Index()
        {
            List<Client> clients = _service.GetAll();
            return View(clients);
        }

        // GET: Client/Details/5
        public ActionResult Details(int id)
        {
            return View(_service.GetByID(id));
        }

        // GET: Client/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Client/Create
        [HttpPost]
        public ActionResult Create(Client client)
        {
            try
            {
                _service.Add(client);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Client/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_service.GetByID(id));
        }

        // POST: Client/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Client client)
        {
            try
            {
                _service.Update(client);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Client/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_service.GetByID(id));
        }

        // POST: Client/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                _service.Remove(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
