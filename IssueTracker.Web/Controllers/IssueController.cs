using IssueTracker.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Common.Extensions;

namespace IssueTracker.Web.Controllers
{
    public class IssueController : Controller
    {
        public ActionResult CreateIssue()
        {
            var model = new CreateIssue { IssueTypeOptions = PopulateIssueTypes() };
            return View("CreateIssue", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateIssue(CreateIssue model)
        {
            if (!ModelState.IsValid)
            {
                model.IssueTypeOptions = PopulateIssueTypes(model);
                return View("CreateIssue", model);
            }

            return RedirectToAction("Index", "Home");
        }

        public ActionResult CreateIssueModal()
        {
            var model = new CreateIssue { IssueTypeOptions = PopulateIssueTypes(), IsModal = true };
            return View("CreateIssue", model);
        }

        private IEnumerable<SelectListItem> PopulateIssueTypes(CreateIssue model = null)
        {
            Dictionary<int, string> issues = new Dictionary<int, string> { { 0, "Story" }, { 1, "Task" }, { 2, "Test Task" }, { 3, "Bug" } };

            return issues.AsEnumerable().ToSelectListItems(value => value.Key.ToString(), text => text.Value, selected => model != null && model.IssueType == selected.Key);
        }
    }
}
