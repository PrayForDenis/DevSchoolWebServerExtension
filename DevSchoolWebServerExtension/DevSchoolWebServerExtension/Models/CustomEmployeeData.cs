using DocsVision.BackOffice.WebClient.Department;
using DocsVision.BackOffice.WebClient.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DevSchoolWebServerExtension.Models
{
    public class CustomEmployeeData
    {
        public EmployeeModel Director { get; set; }
        public string Phone { get; set; }
        public DepartmentModel Unit { get; set; }
    }
}