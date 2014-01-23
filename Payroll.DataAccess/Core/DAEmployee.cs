using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll.DataAccess.Core
{
    public class DAEmployee
    {
        public Guid Create(Employee entity)
        {
            try
            {
                PayrollDataContext context = new PayrollDataContext();
                if (entity.Id == Guid.Empty)
                    entity.Id = Guid.NewGuid();

                context.Employees.InsertOnSubmit(entity);
                context.SubmitChanges(); 
            }
            catch(Exception ex)
            {
                throw ex;
            }

            return entity.Id;
        }

        public void Update(Employee employee)
        {
            try
            {
                PayrollDataContext context = new PayrollDataContext();
                if (employee.Id == Guid.Empty)
                    return;

                var entity = context.Employees.Where(x => x.Id == employee.Id).FirstOrDefault();
                entity.EmployeeNumber = employee.EmployeeNumber;
                entity.Title = employee.Title;
                entity.FirstName = employee.FirstName;
                entity.MiddleName = employee.MiddleName;
                entity.LastName = employee.LastName;
                entity.Age = employee.Age;
                entity.Birthdate = employee.Birthdate;
                entity.Sex = employee.Sex;
                entity.CivilStatus = employee.CivilStatus;
                entity.HomePhone = employee.HomePhone;
                entity.MobilePhone = employee.MobilePhone;
                entity.Email = employee.Email;
                entity.PresentHomeAddressId = employee.PresentHomeAddressId;
                entity.DepartmentCode = employee.DepartmentCode;
                entity.PositionCode = employee.PositionCode;
                entity.TaxStatusCode = employee.TaxStatusCode;
                entity.HireDate = employee.HireDate;
                entity.EmployementTypeCode = employee.EmployementTypeCode;
                entity.SSSNumber = employee.SSSNumber;
                entity.TINNumber = employee.TINNumber;
                entity.PagIbigNumber = employee.PagIbigNumber;
                entity.PhilHealthNumber = employee.PhilHealthNumber;
                entity.SalaryRate = employee.SalaryRate;
                entity.CurrentSalary = employee.CurrentSalary;
                entity.BankNameCode = employee.BankNameCode;
                entity.AccountNumber = employee.AccountNumber;
                entity.EmployeeStatus = employee.EmployeeStatus;
                
                context.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void Delete(Guid id)
        {
            try
            {
                PayrollDataContext context = new PayrollDataContext();

                var entity = context.Employees.Where(x => x.Id == id).FirstOrDefault();
                entity.IsDeleted = true;
                
                context.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public Employee GetById(Guid id)
        {
            PayrollDataContext context = new PayrollDataContext();
            return context.Employees.Where(x => x.Id  == id).FirstOrDefault();
        }

        public Employee FindByEmployeeNumber(int employeeNumber)
        {
            PayrollDataContext context = new PayrollDataContext();
            return context.Employees.Where(x => x.EmployeeNumber == employeeNumber).FirstOrDefault();
        }

        public List<Employee> List()
        {
            PayrollDataContext context = new PayrollDataContext();
            return context.Employees.Where(x => x.IsDeleted == false).ToList();
        }

        public void CreateAddress(EmployeeAddress address)
        {
            try
            {
                PayrollDataContext context = new PayrollDataContext();
                if (address.Id == Guid.Empty)
                    address.Id = Guid.NewGuid();

                if (address.EmployeeId == Guid.Empty)
                    throw new Exception("Cannot add address to empty employee id");

                context.EmployeeAddresses.InsertOnSubmit(address);
                context.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public List<EmployeeAddress> GetAddressList()
        {
            PayrollDataContext context = new PayrollDataContext();
            return context.EmployeeAddresses.ToList();
        }
    }
}
