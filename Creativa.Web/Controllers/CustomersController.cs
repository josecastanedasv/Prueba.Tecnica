using System.Linq;
using System.Web.Mvc;
using Creativa.Web.NorthwindServiceRef; 

namespace Creativa.Web.Controllers
{
    public class CustomersController : Controller
    {
        private readonly NorthwindServiceClient _client = new NorthwindServiceClient();

        public ActionResult Index()
        {
            var customers = _client.GetCustomers().ToList();
            return View(customers);
        }

        public ActionResult Orders(string id)
        {
            var client = new NorthwindServiceClient();
            var orders = client.GetOrdersByCustomer(id);

            ViewBag.CustomerID = id;
            return View(orders);
        }
    }
}
