using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Common.Extensions
{
    public static class IEnumerable
    {
        public static IEnumerable<SelectListItem> ToSelectListItems<T>(this IEnumerable<T> collection, Func<T, string> value, Func<T, string> text, Func<T, bool> selected)
        {
            List<SelectListItem> items = new List<SelectListItem>();

            items.AddRange(collection.Select(item => new SelectListItem { Value = value.Invoke(item), Text = text.Invoke(item), Selected = selected.Invoke(item) }));
            items.Insert(0, new SelectListItem { Value = "", Text = "Please select", Selected = !items.Any(x => x.Selected == true) });

            return items;
        }
    }
}
