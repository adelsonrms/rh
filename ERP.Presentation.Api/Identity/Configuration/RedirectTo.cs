using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERP.Presentation.Api.Identity.LoginManager
{
    public class RedirectTo
    {
        public string Controller { get; set; }
        public string Action { get; set; }
        public string Url { get; set; }
        public bool Success { get; set; }
        public dynamic RouterArgs { get; set; }
    }
}