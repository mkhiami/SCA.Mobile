﻿using System.Web;
using System.Web.Mvc;

namespace SCA.Mobile.API
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
