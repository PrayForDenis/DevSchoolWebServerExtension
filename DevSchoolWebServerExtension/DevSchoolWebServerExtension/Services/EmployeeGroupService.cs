using DocsVision.BackOffice.ObjectModel.Services;
using DocsVision.BackOffice.ObjectModel;
using DocsVision.BackOffice.WebClient.Employee;
using DocsVision.Platform.WebClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DevSchoolWebServerExtension.Services
{
    public class EmployeeGroupService : IEmployeeGroupService
    {
        public EmployeeModel[] GetEmployeeGroup(SessionContext context, string groupName)
        {
            IStaffService staffService = context.ObjectContext.GetService<IStaffService>();
            StaffGroup group = staffService.FindGroupByName(null, groupName);
            if (group == null) { return null; }
            IEnumerable<StaffEmployee> employees = staffService.GetGroupEmployees(group);
            List<EmployeeModel> employeesModel = new List<EmployeeModel>();
            foreach (StaffEmployee employee in employees)
            {
                var model = new EmployeeModel();
                model.Initialize(employee);
                employeesModel.Add(model);
            }
            return employeesModel.ToArray();
        }
    }
}