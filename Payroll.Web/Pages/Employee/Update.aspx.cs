using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Payroll.Web.Pages.Employee
{
    public partial class Update : BasePage
    {
        private Guid Id
        {
            get
            {
                return new Guid(Request.QueryString["Id"].ToString());
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            btnCancel.Click += btnCancel_Click;
            btnSave.Click += btnSave_Click;

            if (!IsPostBack)
                Bind();
        }

        void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                DataAccess.Core.DAEmployee empService = new DataAccess.Core.DAEmployee();

                var employee = empService.GetById(Id);                                

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

                DataAccess.EmployeeAddress address = empService.GetEmployeeAddressList(employee.Id).FirstOrDefault();
                if (address == null)
                {
                    address = new DataAccess.EmployeeAddress();
                    address.AddressTypeCode = "Permanent";
                    address.EmployeeId = employee.Id;
                }
                address.Address = txtAddress.Text;
                address.CityMun = TxtCityMun.Text;
                address.ProvState = string.IsNullOrEmpty(txtProvState.Text) ? null : txtProvState.Text;
                address.CountryCode = string.IsNullOrEmpty(ddlCountry.SelectedValue) ? null : ddlCountry.SelectedValue;
                address.ZipCode = txtZipCode.Text;
                               
                empService.Update(employee);

                if (address.Id == null || address.Id == Guid.Empty)                
                    empService.CreateAddress(address);
                else
                    empService.UpdateEmployeeAddress(address);
     

                SetMessage(MessageType.Succes, "Saving successfull",true);

                RedirectToReferrerUrl();
  
            }
            catch (Exception ex)
            {
                SetMessage(MessageType.Error, string.Format("Saving failed: {0}", ex.Message));
            }
        }

        void btnCancel_Click(object sender, EventArgs e)
        {
            RedirectToReferrerUrl();
        }

        void Bind()
        {
            DataAccess.Core.DAEmployee empService = new DataAccess.Core.DAEmployee();
            var employee = empService.GetById(Id);

            txtEmployeeNumber.Text  = employee.EmployeeNumber.ToString();
            txtTitle.Text = employee.Title;
            txtFname.Text = employee.FirstName;
            txtMname.Text = employee.MiddleName;
            txtLname.Text = employee.LastName;
            txtAge.Text  = employee.Age.ToString();
            txtBirthDate.Text = employee.Birthdate.ToShortDateString();
            ddlSex.SelectedValue  = employee.Sex.ToString();
            ddlCivilStatus.SelectedValue = employee.CivilStatus;
            txtHomePhone.Text = employee.HomePhone;
            txtMobile.Text = employee.MobilePhone;
            txtEmail.Text = employee.Email;
            //entity.PresentHomeAddressId = employee.PresentHomeAddressId;
            ddlDepartment.SelectedValue =  employee.DepartmentCode;
            ddlPosition.SelectedValue = employee.PositionCode;
            ddlTaxStatus.SelectedValue  = employee.TaxStatusCode;
            txtHiredDate.Text = employee.HireDate.ToShortDateString();
            ddlEmployeeType.SelectedValue = employee.EmployementTypeCode;
            txtSSSNumber.Text = employee.SSSNumber.ToString();
            txtTIN.Text = employee.TINNumber.ToString();
            txtPagIbig.Text = employee.PagIbigNumber.ToString();
            txtPhilHealth.Text = employee.PhilHealthNumber.ToString();
            txtSalaryRate.Text = employee.SalaryRate;
            txtCurrentSalary.Text = employee.CurrentSalary.ToString();
            ddlBankName.SelectedValue  = employee.BankNameCode;
            txtAccountNumber.Text = employee.AccountNumber.ToString();
            ddlEmpStatus.SelectedValue = employee.EmployeeStatus;

            var empAddress = empService.GetEmployeeAddressList(employee.Id).FirstOrDefault();
            if (empAddress != null)
            {
                txtAddress.Text = empAddress.Address;
                TxtCityMun.Text = empAddress.CityMun;
                txtProvState.Text = empAddress.ProvState;
                txtZipCode.Text = empAddress.ZipCode;
                ddlCountry.SelectedValue = empAddress.CountryCode;
            }
                
        }
    }
}