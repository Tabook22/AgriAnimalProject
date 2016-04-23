using AnimalVaccProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AnimalVaccProject.Controllers
{
    public class testController : Controller
    {
        // GET: test
        public ActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public PartialViewResult AdminMenu()
        {
            //create alist of menu adimn menu
            var items = new List<AdminMenuItem>();//this will contains the list which then we are going to sent to the partial view
                                                  //first check to see if the user in authenticated, then we care going to display the differen links for our menus
            if (User.Identity.IsAuthenticated)
            {
                items.Add(new AdminMenuItem
                {
                    Text = "Amin Home",
                    Action = "Index",
                    RouteInfo = new { controller = "admin", area = "admin" }
                });

                if (User.IsInRole("admin"))
                {
                    items.Add(new AdminMenuItem
                    {
                        Text = "Users",
                        Action = "Index",
                        RouteInfo = new { controller = "user", area = "admin" }
                    });
                }
                else
                {
                    items.Add(new AdminMenuItem
                    {
                        Text = "Profile",
                        Action = "edit",
                        RouteInfo = new { controller = "user", area = "admin", username = User.Identity.Name }
                    });
                }
                //the next element in our list is tags likns and we only show tags for admin and editors

                if (!User.IsInRole("author"))
                {
                    items.Add(new AdminMenuItem
                    {
                        Text = "Tags",
                        Action = "Index",
                        RouteInfo = new { controller = "tag", area = "admin" }
                    });
                }
                //the final element in our list is the post and every one can see the posts
                items.Add(new AdminMenuItem
                {
                    Text = "Posts",
                    Action = "Index",
                    RouteInfo = new { controller = "post", area = "admin" }
                });
            }
            return PartialView("items");
        }
    }
}