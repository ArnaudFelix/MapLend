using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using MapLend.Business;
using MapLend.Mvc.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace MapLend.Mvc.Infrastructure
{
    public abstract class MapControllerBase : Controller
    {
        protected User CurrentUser { get; private set; }
        protected ApplicationDbContext DbCtx { get; private set; }

        protected MapControllerBase() : base()
        {
            DbCtx = new ApplicationDbContext();
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {

            var user = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(User.Identity.GetUserId());

            if (CurrentUser == null)
            {
                string username = User.Identity.Name;
                CurrentUser = DbCtx.MapUsers.Include(u => u.Photo).Single(u => u.Username == username);
            }

            base.OnActionExecuting(filterContext);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && DbCtx != null)
            {
                DbCtx.Dispose();
                DbCtx = null;
            }

            base.Dispose(disposing);
        }
    }
}