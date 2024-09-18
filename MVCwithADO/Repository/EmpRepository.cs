using MVCwithADO.Models;
using MVCwithADO.Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Reflection;
using System.Web;

namespace MVCwithADO.Repository
{
    public class EmpRepository
    {
        SqlCommand cmd;
        sqlDal obj;
        public List<EmployeeViewModel> GetAllEmployees()
        {
            List<EmployeeViewModel> empList = new List<EmployeeViewModel>();
            cmd = new SqlCommand();
            obj = new sqlDal();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "sp_EmpDetails";
            cmd.Parameters.AddWithValue("@action", "FindAll");
            cmd.Parameters.AddWithValue("@deleted", false);
            DataSet ds = obj.ExecuteDataSet(cmd);
            DataTable dt = ds.Tables[0];
            foreach (DataRow emp in dt.Rows)
            {
                empList.Add(new EmployeeViewModel()
                {
                    Empid = Convert.ToInt32(emp["EmpId"]),
                    Name = emp["EmployeeName"].ToString(),
                    DesignationId = Convert.ToInt32(emp["DesignationId"]),
                    DesignationName = emp["Designation"].ToString(),
                    City = emp["City"].ToString(),
                    Address = emp["Address"].ToString(),
                    Salary = Convert.ToDecimal(emp["Salary"])
                    
                }
                );
            }
            return empList;
        }
        public List<Designation> GetDesignation()
        {
            List<Designation> empList = new List<Designation>();
            cmd = new SqlCommand();
            obj = new sqlDal();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "sp_EmpDetails";
            cmd.Parameters.AddWithValue("@action", "FindAllDesignation");
            cmd.Parameters.AddWithValue("@deleted", false);
            DataSet ds = obj.ExecuteDataSet(cmd);
            DataTable dt = ds.Tables[0];
            foreach (DataRow emp in dt.Rows)
            {
                empList.Add(new Designation()
                {
                   
                    DesignationId = Convert.ToInt32(emp["DesignationId"]),
                    DesignationName = emp["Designation"].ToString(),
                   
                }
                );
            }
            return empList;
        }
        public bool AddEmployee(EmployeeViewModel Model)
        {
            cmd = new SqlCommand();
            obj = new sqlDal();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "sp_Add_Update_EmpDetails";
            cmd.Parameters.AddWithValue("@action", "AddEmployee");
            cmd.Parameters.AddWithValue("@EmpId", Model.Employee.Empid);
            cmd.Parameters.AddWithValue("@EmpName", Model.Employee.Name);
            cmd.Parameters.AddWithValue("@DesignationId", Model.Designation.DesignationId);
            cmd.Parameters.AddWithValue("@City", Model.Employee.City);
            cmd.Parameters.AddWithValue("@Address", Model.Employee.Address);
            cmd.Parameters.AddWithValue("@Salary", Model.Employee.Salary);
            cmd.Parameters.AddWithValue("@deleted", false);
            int i = obj.ExecuteNonQuery(cmd);
            if (i>0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool UpdateEmployee(EmployeeViewModel Model)
        {
            cmd = new SqlCommand();
            obj = new sqlDal();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "sp_Add_Update_EmpDetails";
            cmd.Parameters.AddWithValue("@action", "UpdateEmployee");
            cmd.Parameters.AddWithValue("@EmpId", Model.Empid);
            cmd.Parameters.AddWithValue("@EmpName", Model.Name);
            cmd.Parameters.AddWithValue("@DesignationId", Model.DesignationId);
            cmd.Parameters.AddWithValue("@City", Model.City);
            cmd.Parameters.AddWithValue("@Address", Model.Address);
            cmd.Parameters.AddWithValue("@Salary", Model.Salary);
            cmd.Parameters.AddWithValue("@deleted", false);
            int i = obj.ExecuteNonQuery(cmd);
            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool DeleteEmployee(int empId)
        {
            cmd = new SqlCommand();
            obj = new sqlDal();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "sp_Add_Update_EmpDetails";
            cmd.Parameters.AddWithValue("@action", "DeleteEmployee");
            cmd.Parameters.AddWithValue("@EmpId", empId);
            cmd.Parameters.AddWithValue("@EmpName", "");
            cmd.Parameters.AddWithValue("@DesignationId", 0);
            cmd.Parameters.AddWithValue("@City", "");
            cmd.Parameters.AddWithValue("@Address", "");
            cmd.Parameters.AddWithValue("@Salary", 0);
            cmd.Parameters.AddWithValue("@deleted", true);
            int i = obj.ExecuteNonQuery(cmd);
            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}