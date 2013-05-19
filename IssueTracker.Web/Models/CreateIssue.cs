using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IssueTracker.Web.Models
{
    public class CreateIssue
    {
        [MaxLength(2000, ErrorMessage="Maximum allowed characters is 2000")]
        [Display(Name="Description")]
        public string Description { get; set; }

        public bool IsModal { get; set; }

        [Required(ErrorMessage="Please select an issue type")]
        [Display(Name="Issue type")]
        public int? IssueType { get; set; }

        public IEnumerable<SelectListItem> IssueTypeOptions { get; set; }

        [Required(AllowEmptyStrings=false, ErrorMessage="Title cannot be empty")]
        [Display(Name="Title")]
        public string Title { get; set; }
    }
}