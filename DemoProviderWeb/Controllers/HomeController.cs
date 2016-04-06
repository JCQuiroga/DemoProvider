using Microsoft.SharePoint.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DemoProviderWeb.Models;

namespace DemoProviderWeb.Controllers
{
    public class HomeController : Controller
    {
        [SharePointContextFilter]
        public ActionResult Index()
        {
            User spUser = null;

            var spContext = SharePointContextProvider.Current.GetSharePointContext(HttpContext);
            var data = new List<TelefonoViewModel>();

            using (var clientContext = spContext.CreateUserClientContextForSPHost())
            {
                if (clientContext != null)
                {
                    var telefonosList = clientContext.Web.Lists.GetByTitle("Telefonos");
                    clientContext.Load(telefonosList);
                    clientContext.ExecuteQuery();

                    var query = new CamlQuery();
                    var telefonosItems = telefonosList.GetItems(query);//Hay que pasarle la query aunq sea vacía (para no filtrar nada)
                    clientContext.Load(telefonosItems);
                    clientContext.ExecuteQuery();

                    foreach (var telefonosItem in telefonosItems)
                    {
                        data.Add(TelefonoViewModel.FromListItem(telefonosItem));
                    }
                }
            }

            return View(data);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
