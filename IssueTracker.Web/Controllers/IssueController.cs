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
            CreateIssue model = CreateIssueModel();
            return View("CreateIssue", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateIssue(CreateIssue model)
        {
            if (!ModelState.IsValid && model.IsModal)
            {
                return PartialView("CreateIssue", CreateIssueModel(model, true));
            }
            else if (!ModelState.IsValid)
            {
                return PartialView("CreateIssue", CreateIssueModel(model, false));
            }
            else if (model.IsModal)
            {
                return Content("OK");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public ActionResult CreateIssueModal()
        {
            CreateIssue model = CreateIssueModel(true);
            return View("CreateIssue", model);
        }

        private IEnumerable<SelectListItem> PopulateIssueTypes(CreateIssue model = null)
        {
            Dictionary<int, string> issues = new Dictionary<int, string> { { 0, "Story" }, { 1, "Task" }, { 2, "Test Task" }, { 3, "Bug" } };

            return issues.AsEnumerable().ToSelectListItems(value => value.Key.ToString(), text => text.Value, selected => model != null && model.IssueType == selected.Key);
        }

        [ChildActionOnly]
        private CreateIssue CreateIssueModel()
        {
            return CreateIssueModel(null, false);
        }

        [ChildActionOnly]
        private CreateIssue CreateIssueModel(bool isModal)
        {
            return CreateIssueModel(null, isModal);
        }

        [ChildActionOnly]
        private CreateIssue CreateIssueModel(CreateIssue model, bool isModal)
        {
            if (model == null)
            {
                model = new CreateIssue { IsModal = isModal };
            }

            model.IssueTypeOptions = PopulateIssueTypes(model);

            return model;
        }
    }
}
