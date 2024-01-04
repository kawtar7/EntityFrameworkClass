using Microsoft.AspNetCore.Mvc;

using EntityFrameworkClass.Data;
using EntityFrameworkClass.Models;

namespace EntityFrameworkClass.Controllers
{
    public class ClientController : Controller
    {
        private readonly ClientDbContext _dbClientContext;

        public ClientController(ClientDbContext dbClientContext)
        {
            _dbClientContext = dbClientContext;
        }

        public IActionResult Index()
        {

            List<Client> clients = _dbClientContext.Clients.ToList();
            return View(clients);

        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create([Bind("Id", "Nom", "Prenom", "Ville")] Client client)
        {
            _dbClientContext.Add(client);
            _dbClientContext.SaveChanges();
            return RedirectToAction("Index");

        }
        public IActionResult Edit(int Id)
        {
            // Retrieve the client from the database
            var client = _dbClientContext.Clients.Find(Id);



            return View(client);
        }

        [HttpPost]
        public IActionResult Edit([Bind("Id", "Nom", "Prenom", "Ville")] Client client)
        {
            
                _dbClientContext.Update(client);
                _dbClientContext.SaveChanges();
                return RedirectToAction("Index");
            

            
        }

        //public IActionResult Delete(int id)v
        //{
        //    // Retrieve the client from the database
        //    var client = _dbClientContext.Clients.Find(id);

        //    if (client == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(client);
        //}

        //[HttpPost, ActionName("Delete")]
        //public IActionResult DeleteConfirmed(int id)
        //{
        //    // Delete the client from the database
        //    var client = _dbClientContext.Clients.Find(id);

        //    if (client != null)
        //    {
        //        _dbClientContext.Clients.Remove(client);
        //        _dbClientContext.SaveChanges();
        //    }

        //    return RedirectToAction("Index");
        //}
        public IActionResult Delete(int id)
        {
         // Retrieve the client from the database
            var client = _dbClientContext.Clients.Find(id);

            if (client != null)
                
                {
                       _dbClientContext.Clients.Remove(client);
                        _dbClientContext.SaveChanges();
                }

            return RedirectToAction("Index");
        }
    }
}

