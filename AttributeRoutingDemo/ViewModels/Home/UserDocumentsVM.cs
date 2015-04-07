using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AttributeRoutingDemo.ViewModels.Home
{
    public class UserDocumentsVM
    {
        public int UserID { get; set; }

        public string SelectedFilter { get; set; }
        public List<string> Filters { get; set; }
    }
}