using DocsVision.BackOffice.WebClient.Employee;
using DocsVision.Platform.WebClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DevSchoolWebServerExtension.Services
{
    public interface IEmployeeGroupService
    {
        /// <summary>
        /// Получение сотрудников из определённой группы справочника сотрудников
        /// </summary>
        /// <param name="context">Контекст ВК</param>
        /// <param name="groupName">Наименование группы</param>
        /// <returns></returns>
        EmployeeModel[] GetEmployeeGroup(SessionContext context, string groupName);
    }
}