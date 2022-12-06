using DevSchoolWebServerExtension.Models;
using DocsVision.BackOffice.ObjectModel;
using DocsVision.BackOffice.WebClient.Department;
using DocsVision.BackOffice.WebClient.Employee;
using DocsVision.Platform.WebClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DevSchoolWebServerExtension.Services
{
    public class CustomEmployeeService : ICustomEmployeeService
    {
        public CustomEmployeeData GetEmployeeData(SessionContext context, Guid employeeId)
        {
            StaffEmployee employee = context.ObjectContext.GetObject<StaffEmployee>(employeeId);
            if (employee == null) { return null; }
            CustomEmployeeData model = new CustomEmployeeData() {
                Phone = employee.Phone,
            };
            DepartmentModel depModel = new DepartmentModel();
            depModel.Initialize(employee.Unit);
            model.Unit = depModel;
            StaffEmployee director = employee.Manager != null ? employee.Manager : employee.Unit.Manager;
            if (director != null) {
                EmployeeModel directorModel = new EmployeeModel();
                directorModel.Initialize(director);
                model.Director = directorModel;
            }
            return model;
        }
    }
}