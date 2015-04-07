using AttributeRoutingDemo.ViewModels.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AttributeRoutingDemo.Controllers
{
    [RoutePrefix("Users")] //Route Prefix specifies a string that all actions in this controller must have at the beginning of their route.
    [Route("{action=index}")] //You can pass default action or controller values into Route attributes.
    public class HomeController : Controller
    {
        [Route("~/")] //Specifies that this is the default action for the entire application
        [Route("")] //Specifies that this is the default action for prefix "Users"
        [Route("Index")] //Specifies that /Users/Index is a valid route for this action (without this attribute \Users\Index will match the route for Details below and throw an exception).
        public ActionResult Index()
        {
            return View();
        }

        [Route("{id}")] //Route: Users/12
        public ActionResult Details(int id)
        {
            return View(id);
        }

        [Route("{id:int}/Documents/{filter?}")] //You can specify route value constraints like {id:int}, which specifies that id must be of type int32.
                                                //The ? specifies that a route value is optional.
        [HttpGet]
        public ActionResult Documents(int id, string filter)
        {
            UserDocumentsVM model = new UserDocumentsVM()
            {
                UserID = id,
                SelectedFilter = filter,
                Filters = new List<string>() { "Excel", "Word", "PowerPoint" }
            };
            return View(model);
        }

        [HttpPost]
        [Route("{id:int}/Documents/{filter?}")]
        public ActionResult Documents(UserDocumentsVM model)
        {
            return RedirectToAction("Documents", new { id = model.UserID, filter = model.SelectedFilter });
        }

        [HttpGet]
        [Route("~/spotlight")] //You can use ~/ to override the RoutePrefix.
        public ActionResult SpotlightUser()
        {
            return RedirectToAction("Details", new { id = 4 });
        }
    }
}