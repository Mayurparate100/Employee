using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Employee.Data;

namespace Employee.Models
{
    public class Departmentmodel
    {
        public int id { get; set; }
        public string DptName { get; set; }
        public string EmpName { get; set; }
        public string EmpsSalary { get; set; }
        public string EmpContact { get; set; }
        public string EmpCity { get; set; }

        public string saveDepartment(Departmentmodel model)
        {
            string msg = "";
            EmployeeEntities db = new EmployeeEntities();
            var AddDepartment = new tblDepartment()
            {
                id = model.id,
                DptName = model.DptName,
                EmpName = model.EmpName,
                EmpsSalary = model.EmpsSalary,
                EmpContact = model.EmpContact,
                EmpCity = model.EmpCity,
            };

            db.tblDepartments.Add(AddDepartment);
            db.SaveChanges();
            return msg;

        }
        public List<Departmentmodel> GetDepartmentList()
        {
            EmployeeEntities db = new EmployeeEntities();
            List<Departmentmodel> lstDepartment = new List<Departmentmodel>();
            var AddDepartmentList = db.tblDepartments.ToList();
            {
                if (AddDepartmentList != null)
                {
                    foreach (var Department in AddDepartmentList)
                    {
                        lstDepartment.Add(new Departmentmodel()
                      {
                            id = Department.id,
                            DptName = Department.DptName,
                            EmpName = Department.EmpName,
                            EmpsSalary = Department.EmpsSalary,
                            EmpContact = Department.EmpContact,
                            EmpCity = Department.EmpCity,

                        });
                    }
                

                    }
                    return lstDepartment;
                }
            }
        }
    }