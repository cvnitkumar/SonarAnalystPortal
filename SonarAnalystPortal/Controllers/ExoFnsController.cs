using BusinessAccess;
using SonarAnalystPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SonarAnalystPortal.Controllers
{
    public class ExoFnsController : Controller
    {
        string user;

        public ExoFnsController()
        {
            
        }

        // GET: ExoFns
        public ActionResult Index()
        {
            return new EmptyResult();
        }

        public ActionResult GetNonAssignedData()
        {            
            var baObj = new EntitySubmissionBA();
            var fnList = baObj.GetEntitySubmissionList().Select(a=> new ATPFnDetail(a));

            return Json(new { data = fnList }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetAssignedData()
        {
            var baObj = new EntitySubmissionBA();
            var fnList = baObj.GetEntitySubmissionList().Select(a => new ATPFnDetail(a));
            return Json(new { data = fnList }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult AssignEntity(List<ATPFnDetail> entities)
        {
            user = ((System.Security.Claims.ClaimsIdentity)(User.Identity)).Name.Split('@')[0].Trim();
            var baObj = new EntitySubmissionBA();
            baObj.AssignEntities(entities.Select(a=> a.ToData()).ToList(), user);
            return Json(new { data = true }, JsonRequestBehavior.AllowGet);
        }
    }
}