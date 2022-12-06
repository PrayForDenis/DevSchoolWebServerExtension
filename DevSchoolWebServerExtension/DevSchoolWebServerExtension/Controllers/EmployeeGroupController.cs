using DevSchoolWebServerExtension.Services;
using DocsVision.Platform.WebClient.Helpers;
using DocsVision.Platform.WebClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DocsVision.BackOffice.WebClient.Employee;
using DocsVision.Platform.WebClient.Models;

namespace DevSchoolWebServerExtension.Controllers
{
    public class EmployeeGroupController : Controller
    {
        private readonly ICurrentObjectContextProvider _objectContextProvider;
        private readonly IEmployeeGroupService _employeeGroupService;

        public EmployeeGroupController(ICurrentObjectContextProvider objectContextProvider, IEmployeeGroupService employeeGroupService)
        {
            _objectContextProvider = objectContextProvider;
            _employeeGroupService = employeeGroupService;
        }

        public ActionResult GetEmployeeGroup(string groupName)
        {
            SessionContext sessionContext = _objectContextProvider.GetOrCreateCurrentSessionContext();
            EmployeeModel[] group = _employeeGroupService.GetEmployeeGroup(sessionContext, groupName);
            return Content(JsonHelper.SerializeToJson(CommonResponse.CreateSuccess(group)));
        }
    }
}