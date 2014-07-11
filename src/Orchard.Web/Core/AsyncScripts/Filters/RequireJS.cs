﻿using System.Web.Mvc;
using Orchard.Environment.Extensions;
using Orchard.Mvc.Filters;
using Orchard.UI.Resources;

namespace Orchard.Core.AsyncScripts.Filters {
    [OrchardFeature("AsyncScripts.RequireJS")]
    public class RequireJS : FilterProvider, IResultFilter {
        public RequireJS(IResourceManager resourceManager) {
            _resourceManager = resourceManager;
        }

        private readonly IResourceManager _resourceManager;

        public void OnResultExecuting(ResultExecutingContext filterContext) {
            if (!(filterContext.Result is ViewResult)) {
                return;
            }

            _resourceManager.Include("script", "~/Core/AsyncScripts/RequireJS/Scripts/require.js", null).AtHead();
        }

        public void OnResultExecuted(ResultExecutedContext filterContext) {
        }
    }
}