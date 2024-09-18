using MVCwithADO.Models;
using MVCwithADO.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace MVCwithADO.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        EmpRepository empRepository;
        public ActionResult GetAllEmployee()
        {
            try
            {
                empRepository = new EmpRepository();

                return View(empRepository.GetAllEmployees());
            }
            catch (Exception ex)
            {

                throw;
            }
            
        }
        public ActionResult AddEmployee()
        {
            var viewModel = new EmployeeViewModel
            {
                Employee = new Employee(),
                DesignationList = new SelectList(new EmpRepository().GetDesignation(), "DesignationId", "DesignationName")
            };

            return View(viewModel);
        }
        [HttpPost]
        public ActionResult AddEmployee(EmployeeViewModel model)
        {
            try
            {
               
                if (ModelState.IsValid)
                {
                    empRepository = new EmpRepository();
                    if (empRepository.AddEmployee(model))
                    {
                        TempData["SuccessMessage"] = "Employee Added Successfully";
                    }
                }
                return RedirectToAction("GetAllEmployee");
            }
            catch (Exception ex)
            {

                throw;
            }
            
        }
        public ActionResult Edit(int id)
        {
            empRepository = new EmpRepository();
            EmployeeViewModel employee = new EmployeeViewModel();
              employee=  empRepository.GetAllEmployees().Find(m => m.Empid == id);

            if (employee == null)
            {
                return HttpNotFound(); // Handle not found
            }

            var viewModel = new EmployeeViewModel
            {
                Empid=employee.Empid,
                Name=employee.Name,
                City=employee.City,
                Salary=employee.Salary,
                Address=employee.Address,
                DesignationId=employee.DesignationId,
                DesignationList = new SelectList(empRepository.GetDesignation(), "DesignationId", "DesignationName", employee.DesignationId)
            };

            return View(viewModel);

        }
        [HttpPost]
        public ActionResult Edit(EmployeeViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    empRepository = new EmpRepository();
                    // Logic to update the employee in the database
                    if (empRepository.UpdateEmployee(model))
                    {
                        TempData["SuccessMessage"] = "Employee updated successfully!";
                    }                   
                }
                return RedirectToAction("GetAllEmployee");
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public ActionResult DeleteEmployee(int id)
        {
            empRepository = new EmpRepository();
            if (empRepository.DeleteEmployee(id))
            {
                TempData["SuccessMessage"] = "Employee Deleted successfully!";
            }
            return RedirectToAction("GetAllEmployee");
        }
    }
}