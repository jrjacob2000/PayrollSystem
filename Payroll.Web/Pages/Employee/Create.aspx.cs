using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Payroll.DataAccess.Core;

namespace Payroll.Web.Pages.Employee
{
    public partial class Create : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            btnSave.Click += btnSave_Click;
            btnCancel.Click += btnCancel_Click;
        }

        void btnCancel_Click(object sender, EventArgs e)
        {
            RedirectToReferrerUrl();
        }

        void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                DataAccess.Employee employee = new DataAccess.Employee();

                employee.EmployeeNumber = txtEmployeeNumber.Text.ToInteger();
                employee.Title = txtTitle.Text;
                employee.FirstName = txtFname.Text;
                employee.MiddleName = txtMname.Text;
                employee.LastName = txtLname.Text;
                employee.Age = txtAge.Text.ToInteger();
                employee.Birthdate = txtBirthDate.Text.ToDate();
                employee.Sex = char.Parse(ddlSex.SelectedValue);
                employee.CivilStatus = ddlCivilStatus.SelectedValue;
                employee.HomePhone = txtHomePhone.Text;
                employee.MobilePhone = txtMobile.Text;
                employee.Email = txtEmail.Text;
                employee.PresentHomeAddressId = Guid.NewGuid();
                employee.DepartmentCode = ddlDepartment.SelectedValue;
                employee.PositionCode = ddlPosition.SelectedValue;
                employee.TaxStatusCode = ddlTaxStatus.SelectedValue;
                employee.HireDate = txtHiredDate.Text.ToDate();
                employee.EmployementTypeCode = ddlEmployeeType.SelectedValue;
                employee.SSSNumber = txtSSSNumber.Text.ToInteger();
                employee.TINNumber = txtTIN.Text.ToInteger();
                employee.PagIbigNumber = txtPagIbig.Text.ToNullableInteger();
                employee.PhilHealthNumber = txtPhilHealth.Text.ToNullableInteger();
                employee.SalaryRate = txtSalaryRate.Text;
                employee.CurrentSalary = txtCurrentSalary.Text.ToDecimal();
                employee.BankNameCode = ddlBankName.SelectedValue;
                employee.AccountNumber = txtAccountNumber.Text.ToNullableInteger();
                employee.EmployeeStatus = ddlEmpStatus.SelectedValue;

                DAEmployee empService = new DAEmployee();

                var exist = empService.FindByEmployeeNumber(employee.EmployeeNumber);

                if (exist == null)
                {
                    empService.Create(employee);
                    SetMessage(MessageType.Succes, "Saving successfull");
                }
                else
                    SetMessage(MessageType.Error, "Employee number already exist");

                
            }
            catch (Exception ex)
            {
                SetMessage(MessageType.Error , string.Format( "Saving failed: {0}",ex.Message));
            }
        }
    }
}