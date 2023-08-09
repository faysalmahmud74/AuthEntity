using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApp.Models;

namespace WebApp
{
    public class EmployeeRepos
    {
        public int AddEmployee(EmployeeModel model)
        {
            using (var context = new WebAppEntities())
            {
                EmployeeTab s = new EmployeeTab();

                s.Name = model.Name;
                s.Dob = model.Dob;
                s.Email = model.Email;
                s.Phone = model.Phone;

                context.EmployeeTab.Add(s);
                context.SaveChanges();

                return s.Id;
            }
        }
        //
        public List<EmployeeModel> GetAllData()
        {
            using (var context = new WebAppEntities())
            {
                var result = context.EmployeeTab.Select(x => new EmployeeModel()
                {
                    Name = x.Name,
                    Dob = x.Dob,
                    Email = x.Email,
                    Phone = x.Phone
                }
                ).ToList();
                return result;

            }
        }

        public EmployeeModel GetDetails(int id)
        {
            using (var context = new WebAppEntities())
            {
                var result = context.EmployeeTab.Where(x => x.Id == id).Select(x => new EmployeeModel()
                {
                    Name = x.Name,
                    Dob = x.Dob,
                    Email = x.Email,
                    Phone = x.Phone
                }
                ).FirstOrDefault();

                return result;
            }
        }


        public bool UpdateData(int id, EmployeeModel model)
        {
            using (var context = new WebAppEntities())
            {
                var employee = context.EmployeeTab.FirstOrDefault(x => x.Id == id);
                if (employee != null)
                {
                    employee.Name = model.Name;
                    employee.Dob = model.Dob;
                    employee.Email = model.Email;
                    employee.Phone = model.Phone;
                }

                context.SaveChanges();

                return true;
            }
        }

        public bool DeleteData(int id)
        {
            using (var context = new WebAppEntities())
            {
                var employee = context.EmployeeTab.FirstOrDefault(x => x.Id == id);
                if (employee != null)
                {
                    context.EmployeeTab.Remove(employee);
                    context.SaveChanges();
                    return true;
                }

                return false;
            }
        }

    }
}