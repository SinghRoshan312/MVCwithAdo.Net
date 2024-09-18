using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCwithADO.Models
{
    public class EmployeeViewModel
    {       
        public int Empid { get; set; }        
        public string Name { get; set; }
        public string DesignationName { get; set; }
        public int DesignationId { get; set; }
        public string City { get; set; }        
        public string Address { get; set; }
        public decimal Salary { get; set; }
        public Employee Employee { get; set; }
        public Designation Designation { get; set; }
        public SelectList DesignationList { get; set; }
    }
}