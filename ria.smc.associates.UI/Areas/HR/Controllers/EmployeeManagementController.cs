﻿using Microsoft.AspNetCore.Mvc;
using ria.smc.associates.Common.Constants;
using ria.smc.associates.DL.UIDataLayers.HumanResourceManagement;
using ria.smc.associates.DL.UIDataLayers.MasterDate;
using ria.smc.associates.Models.EmployeeManagement;
using ria.smc.associatesDto.EmployeeManagement;

namespace ria.smc.associates.UI.Areas.HR.Controllers
{
    [Area("HR")]
    public class EmployeeManagementController : Controller
    {
        [HttpGet]
        public IActionResult EmployeeList()
        {
            List<EmployeeInformation> employees = HumanResourceDL.GetEmployeeInformation("", "", "", "");
            return View(employees);
        }

        [HttpGet]
        public IActionResult EmployeeRegistration()
        {
            ViewBag.GetGenders = MasterDL.GetGenders();
            ViewBag.GetBloodGroups = MasterDL.GetBloodGroups();
            ViewBag.GetEmployeeTypes = MasterDL.GetEmployeeTypes();
            ViewBag.GetMaritalStatus = MasterDL.GetMaritalStatus();
            ViewBag.GetEmployeeStatus = MasterDL.GetEmployeeStatus();
            ViewBag.MaxEmployeeCode = GetNextEmployeeCode("RIA");
            return View();
        }

        [HttpPost]
        public IActionResult EmployeeRegistration([FromForm] EmployeeInformationDTO employeeInformationDTO)
        {
            string employeeCode = string.Empty;
            if (employeeInformationDTO != null)
            {
                if (ModelState.IsValid)
                {
                    employeeInformationDTO.RecordMode = RecordMode.Added;
                    employeeCode = HumanResourceDL.CreateEmployee(employeeInformationDTO);
                }
            }
            return View();
        }

        public string GetNextEmployeeCode(string prefix)
        {
            string maxEmployeeCode = GetMaxEmployeeCodeFromDB();
            int lastNumber = 0;
            if (!string.IsNullOrEmpty(maxEmployeeCode))
            {
                string[] parts = maxEmployeeCode.Split('-');
                if (parts.Length == 2 && int.TryParse(parts[1], out lastNumber))
                {
                    lastNumber++;
                }
            }
            else
            {
                lastNumber = 1;
            }
            return $"{prefix}-{lastNumber:D4}";
        }

        private string GetMaxEmployeeCodeFromDB()
        {
            string maxEmployeeCode = string.Empty;
            maxEmployeeCode = HumanResourceDL.GetMaxEmployeeCode();
            return maxEmployeeCode;
        }
    }
}
