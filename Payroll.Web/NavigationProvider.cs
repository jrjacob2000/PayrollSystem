using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Framework;



namespace Payroll.Web
{


    public class NavigationProvider : INavigationProvider
{

#region INavigationNodesProvider Members
    public NavigationNodesList GetNodes()
    {

        NavigationNodesList result = new NavigationNodesList();

        //Home
        if (new Operations.ViewHome().IsAuthorized())
        {
            NavigationNode Administrator = result.Add("Home", "/Default.aspx");
        }

        if (new Operations.ViewEmployee().IsAuthorized())
        {
            NavigationNode Employee = result.Add("Employee");
            Employee.Add("New Employee", "/Pages/Employee/Create.aspx");            
        }
       

        // Administration
        if (new Operations.ManageReferencesSecurity().IsAuthorized())
        {
            NavigationNode Administrator = result.Add("Administrator");
            Administrator.Add("Reference Management", "~/Pages/Administration/ReferenceManagement/Default.aspx");

            NavigationNode secMgmt = Administrator.Add("Security Management", string.Empty);
            secMgmt.Add("User Management", "~/Pages/Administration/AccountManagement/Default.aspx");
            secMgmt.Add("Role Management", "~/Pages/Administration/RoleManagement/Default.aspx");

                             
                 
        }

       

        return result;
    }

    //public NavigationEntriesList GetEntries()
    //{

        //SGSNavigationEntriesList result = new SGSNavigationEntriesList();
        //result.Add("Home", "~/Default.aspx");
        //result.Add(/"Search", "~/Pages/Search.aspx");
        //result.Add(/"Contact us", "~/Pages/ContactUs.aspx");
        //return result;

    //}

    //public NavigationSections GetContextualSections()
    //{

    //SGSNavigationSections result = new SGSNavigationSections();
    //new Switch(this.CurrentPage())
    //.Case<Lab.Admin.Web.Pages.Laboratory.Accreditation.

    //Create>(page =>
    //{

    //result.Add(GetLaboratorySection(page.LaboratoryId));

    //})

    //.Case<Lab.Admin.Web.Pages.Laboratory.Accreditation.

    //Update>(page =>
    //{

    //result.Add(GetLaboratorySection(page.Accreditation.LaboratoryId));

    //result.Add(GetAccreditationSection(page.Accreditation));

    //})

    //.Case<Lab.Admin.Web.Pages.Laboratory.Accreditation.

    //View>(page =>
    //{

    //result.Add(GetLaboratorySection(page.Accreditation.LaboratoryId));

    //result.Add(GetAccreditationSection(page.Accreditation));

    //})

    //.Case<Lab.Admin.Web.Pages.Laboratory.Capability.

    //Create>(page =>
    //{

    //result.Add(GetLaboratorySection(page.Laboratory.Id));

    //})

    //.Case<Lab.Admin.Web.Pages.Laboratory.Capability.

    //Update>(page =>
    //{

    //result.Add(GetLaboratorySection(page.Capability.LaboratoryId));

    //result.Add(GetCapabilitySection(page.Capability));

    //})

    //.Case<Lab.Admin.Web.Pages.Laboratory.Capability.

    //View>(page =>
    //{

    //result.Add(GetLaboratorySection(page.Capability.LaboratoryId));

    //result.Add(GetCapabilitySection(page.Capability));

    //})

    //.Case<Lab.Admin.Web.Pages.Laboratory.Measure.

    //Default>(page =>
    //{

    //result.Add(GetLaboratorySection(page.Laboratory.Id));

    //})

    //.Case<Lab.Admin.Web.Pages.Laboratory.

    //Update>(page =>
    //{

    //result.Add(GetLaboratorySection(page.Id));

    //})

    //.Case<Lab.Admin.Web.Pages.Laboratory.

    //View>(page =>
    //{

    //result.Add(GetLaboratorySection(page.LaboratoryId));

    //})

    //;

    //return result;
    //}

    //private bool CanRunReports()
    //{

    //return
    //new LabOperations.RunLabReports().IsAuthorized() //||
    ////new LabOperations.RunXLSReport().IsAuthorized() ||
    //////4. LAB-563: Accreditation : Excel report listing accreditations
    ////new LabOperations.RunAccreditationReport().IsAuthorized() ||
    ////new LabOperations.RunAnalyticalReport().IsAuthorized() ||
    /////*Lab 1505*/
    ////new LabOperations.RunWeeklyAnalyticalReport().IsAuthorized() ||
    //////5. LAB-1506, 1508, 1509
    ////new LabOperations.RunMonthlyFinancialReport().IsAuthorized() ||
    ////new LabOperations.RunAllLaboratoriesReport().IsAuthorized()
    //;

    //}

    //private NavigationSection GetAccreditationSection(Accreditation accreditation)
    //{

    //SGSNavigationSection result = new SGSNavigationSection("Accreditation");
    //// View
    //result.Add(

    //"View", "~/Pages/Laboratory/Accreditation/View.aspx?Id=" + accreditation.Id.ToString());
    //// Edit / Create
    //if (new LabOperations.EditLab { LaboratoryId = accreditation.LaboratoryId }.IsAuthorized())
    //{

    //result.Add(

    //"Edit", "~/Pages/Laboratory/Accreditation/Update.aspx?Id=" + accreditation.Id.ToString());
    //result.Add(

    //"Create", "~/Pages/Laboratory/Accreditation/Create.aspx?Id=" + accreditation.LaboratoryId.ToString());
    //}

    //return result;
    //}

    //public NavigationSection GetCapabilitySection(Capability Capability)
    //{

    //SGSNavigationSection result = new SGSNavigationSection("Capability");
    //// View
    //result.Add(

    //"View", "~/Pages/Laboratory/Capability/View.aspx?Id=" + Capability.Id.ToString() + "&LabId=" + Capability.LaboratoryId);
    //// Edit / Create
    //if (new LabOperations.EditCapability { LaboratoryId = Capability.LaboratoryId }.IsAuthorized())
    //{

    //result.Add(

    //"Edit", "~/Pages/Laboratory/Capability/Update.aspx?Id=" + Capability.Id.ToString() + "&LabId=" + Capability.LaboratoryId);
    //result.Add(

    //"Create", "~/Pages/Laboratory/Capability/Create.aspx?Id=" + Capability.LaboratoryId.ToString());
    //}

    //return result;
    //}

    //public NavigationSection GetLaboratorySection(Guid LabId)
    //{

    //SGSNavigationSection result = new SGSNavigationSection("Laboratory");
    //// View
    //result.Add(

    //"View", "~/Pages/Laboratory/View.aspx?Id=" + LabId.ToString());
    //// Edit
    //if (new LabOperations.EditLab { LaboratoryId = LabId }.IsAuthorized())
    //{

    //result.Add(

    //"Edit", "~/Pages/Laboratory/Update.aspx?Id=" + LabId.ToString());
    //}

    //// Measures
    //if (new LabOperations.EditMeasures { LaboratoryId = LabId }.IsAuthorized())
    //{

    //string currentMonthlyPeriodCode = MeasureHelper.GetCurrentPeriodCode(LABConstants.Measure.FrequencyCode.Monthly);
    //result.Add(

    //"Measures", "~/Pages/Laboratory/Measure/Default.aspx?Id=" + LabId.ToString() + "&" + LABConstants.UrlParameter.MeasurePeriod + "=" + currentMonthlyPeriodCode);
    //}

    ////LAB-440_IF003
    //// Laboratory Report
    //if (new LabOperations.RunLabReports { LaboratoryId = LabId }.IsAuthorized())
    //{

    //result.Add(

    //"[[Laboratory.LaboratoryReport]]", "~/Pages/Laboratory/View.aspx?Id=" + LabId.ToString() + "&&LabReportGenereted=true");
    //}

    ////WI 8707
    //if (new LabOperations.RunLabMeasuresReport{ LaboratoryId = LabId}.IsAuthorized())
    //{

    //result.Add(

    //"Laboratory Measures Report", "~/Pages/Laboratory/View.aspx?Id=" + LabId.ToString() + "&&LabMeasuresGenereted=true");
    //}

    //return result;
    //}

#endregion



    public NavigationEntriesList GetEntries()
    {
        throw new NotImplementedException();
    }

    public NavigationSections GetSections()
    {
        throw new NotImplementedException();
    }
}
}





