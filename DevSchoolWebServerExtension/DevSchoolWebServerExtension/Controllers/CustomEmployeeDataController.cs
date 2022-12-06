using DevSchoolWebServerExtension.Models;
using DevSchoolWebServerExtension.Services;
using DocsVision.Platform.WebClient;
using DocsVision.Platform.WebClient.Helpers;
using DocsVision.Platform.WebClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DevSchoolWebServerExtension.Controllers
{
    public class CustomEmployeeDataController : Controller
    {
        private readonly ICurrentObjectContextProvider _objectContextProvider;
        private readonly ICustomEmployeeService _customEmployeeService;

        public CustomEmployeeDataController(ICurrentObjectContextProvider objectContextProvider, ICustomEmployeeService customEmployeeService) 
        {
            _objectContextProvider = objectContextProvider;
            _customEmployeeService = customEmployeeService;
        }

        public ActionResult GetEmployeeData(Guid employeeId) 
        {
            SessionContext sessionContext = _objectContextProvider.GetOrCreateCurrentSessionContext();
            CustomEmployeeData model = _customEmployeeService.GetEmployeeData(sessionContext, employeeId);
            return Content(JsonHelper.SerializeToJson(CommonResponse.CreateSuccess(model)));
        }
    }
}