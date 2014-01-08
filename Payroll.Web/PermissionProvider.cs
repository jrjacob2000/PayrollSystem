using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Payroll.Web
{
    public static class Operations
    {
        // ONLY Administrators have this role
        public class ManageReferencesSecurity : Operation
        {
            public override string Description
            {
                get { return "Reference & Security management"; }
            }
        }

        public class ViewHome : Operation
        {
            public override string Description
            {
                get { return "Home"; }
            }
        }

        public class ViewEmployee : Operation
        {
            public override string Description
            {
                get { return "Employee"; }
            }
        }

        //public class EditLab : SGSOperation
        //{
        //    public Guid? LaboratoryId { get; set; }
        //    public override string Description
        //    {
        //        get { return "Edit Laboratories"; }
        //    }
        //}

        ////LAB-767_IF009_Security_Capability_management
        //public class EditCapability : SGSOperation
        //{
        //    public Guid? LaboratoryId { get; set; }
        //    public override string Description
        //    {
        //        get { return "Edit Laboratories"; }
        //    }
        //}

       

    }


    public class PermissionProvider : IPermissionProvider
    {

       

        #region Public Methods

        #region ISGSReferencePermissionProvider Members

        public bool IsOperationAuthorized(Operation facts)
        {
            //if (this.Operator() == null)
            //{
            //    ApplicationServer.Instance.Trace("LabPersmissionProvider:IsOperationAuthorized - Operator is null -> return false");
            //    return false;
            //}

            

            if (facts == null) return true;

            bool result = true;
            new Switch(facts)
                .Case<Operations.ManageReferencesSecurity>(x => result = HasPrivilege(x.ToString()))
                .Case<Operations.ViewHome>(x => result = HasPrivilege(x.ToString()))
                
            //    // LAB Actions
            //    .Case<LabOperations.ViewLab>(x => result = HasPrivilege(x.ToString()))
            //    .Case<LabOperations.EditLab>(x => result = CanEditLab(x))
            //    .Case<LabOperations.EditMeasures>(x => result = CanEditMeasure(x))
            //    .Case<LabOperations.RunLabReports>(x => result = CanRunLabReports(x))
            //    //WI 8707
            //    .Case<LabOperations.RunLabMeasuresReport>(x => result = CanRunLabMeasuresReport(x))
            //    .Case<LabOperations.RunXLSReport>(x => result = HasPrivilege(x.ToString()))
            //    //4.	LAB-563: Accreditation : Excel report listing accreditations               
            //    .Case<LabOperations.RunAccreditationReport>(x => result = HasPrivilege(x.ToString()))
            //    .Case<LabOperations.RunLabCapabilities>(x => result = HasPrivilege(x.ToString()))

            //    //6.	LAB-1125: Generate Region/Country-Peer/LOB Summary Report
            //    .Case<LabOperations.RunAllLaboratoriesReport>(x => result = HasPrivilege(x.ToString()))

            //    .Case<LabOperations.RunHighLevelReport>(x => result = HasPrivilege(x.ToString()))

            //    //3.	LAB-541: LABORATORY MEASURE RESPONSE TRACKING DASHBOARD
            //    .Case<LabOperations.RunTrackingDashboard>(x => result = HasPrivilege(x.ToString()))

            //      /*Lab 1505*/
            //    .Case<LabOperations.RunWeeklyAnalyticalReport>(x => result = HasPrivilege(x.ToString()))


            //    .Case<LabOperations.RunMonthlyAnalyticalReport>(x => result = HasPrivilege(x.ToString()))

            //    .Case<LabOperations.ManageReferencesSecurity>(x => result = HasPrivilege(x.ToString()))
            //    .Case<LabOperations.EditTestsMethods>(x => result = HasPrivilege(x.ToString()))
            //    .Case<LabOperations.ViewTestsMethods>(x => result = HasPrivilege(x.ToString()))
            //    .Case<LabOperations.DeleteTests>(x => result = HasPrivilege(x.ToString()) && !DependencyCheck.HasDependency(x))
            //    //WI-2219 : bug  deleting method
            //    .Case<LabOperations.DeleteMethod>(x => result = !DependencyCheck.HasDependency(x))
            //    .Case<LabOperations.UnlinkTestMethods>(x => result = !DependencyCheck.HasDependency(x))
            //    .Case<LabOperations.UnlinkTestSubstances>(x => result = !DependencyCheck.HasDependency(x))
            //    //--end wi-2219

            //    .Case<LabOperations.SearchLabByMeasures>(x => result = HasPrivilege(x.ToString()))
            //    .Case<LabOperations.SearchLabByInstruments>(x => result = HasPrivilege(x.ToString()))
            //    .Case<LabOperations.EditLabManagers>(x => result = HasPrivilege(x.ToString()))
            //    .Case<LabOperations.EditLabPeerGroup>(x => result = HasPrivilege(x.ToString()))
            //    .Case<LabOperations.EditLabCodeAndName>(x => result = HasPrivilege(x.ToString()))
            //    .Case<LabOperations.EditCapability>(x => result = CanEditCapability(x))
            //    .Case<LabOperations.ViewLabInstrument>(x => result = CanViewLabInstrument(x))
            //    .Case<LabOperations.DeleteLabCapabilities>(x => result = HasPrivilege(x.ToString()) && !DependencyCheck.HasDependency(x))
            //    .Case<LabOperations.DeleteLabProducts>(x => result = HasPrivilege(x.ToString()) && !DependencyCheck.HasDependency(x))
            //    .Case<LabOperations.DeleteLabAccreditations>(x => result = HasPrivilege(x.ToString()) && !DependencyCheck.HasDependency(x))
            //    .Case<LabOperations.DeleteMeasure>(x => result = IsAdministrator() && !DependencyCheck.HasDependency(x))
            //    .Case<LabOperations.CreateMeasure>(x => result = IsAdministrator())
            //    .Case<LabOperations.SearchMeasures>(x => result = IsAdministrator())
            //    .Case<LabOperations.EditSlimStatus>(x => result = IsAdministrator())

            //    // SGS Reference Actions
            //    .Case<SGSReferenceOperations.CreateParties>(x => result = IsAdministrator() && x.PartyTypeCode != "Laboratory")
            //    .Case<SGSReferenceOperations.UpdateParties>(x => result = IsAdministrator() && x.PartyTypeCode != "Laboratory")
            //    .Case<SGSReferenceOperations.DeleteParties>(x => result = IsAdministrator() && x.PartyTypeCode != "Laboratory")
            //    .Case<SGSReferenceOperations.DeleteReferenceData>(x => result = IsAdministrator() && !DependencyCheck.IsSystem(x) && !DependencyCheck.HasDependency(x))
            //    .Case<SGSReferenceOperations.DeleteGenericData>(x => result = IsAdministrator() && !DependencyCheck.IsSystem(x) && !DependencyCheck.HasDependency(x))
            //    .Case<SGSReferenceOperations.CreateAddresses>(x => result = string.IsNullOrEmpty(x.AddressTypeCode) || x.AddressTypeCode != "REFERENCE")
            //    .Case<SGSReferenceOperations.CanUseAddressType>(x => result = CanEditAddress(x.AddressId, x.AddressTypeCode))
            //    .Case<SGSReferenceOperations.DeleteAddress>(x => result = CanDeleteAddress(x.AddressId))
            //    .Case<SGSReferenceOperations.UpdateReferenceDataDefaultTranslation>(x => result = IsAdministrator() && CanEditDefaultTranslation(x))

            //    //TFS WI# 9329 
            //    //Assuming that all roles has a read/view previledge to laboratories
            //    .Case<SGSReferenceOperations.ReadParties>(x => result = CandReadParties(x.Id))
            //    // Default -> only administrator
                .Default(x => result = IsAdministrator())
                ;
            return result;
            
        }

        #endregion

        //private bool CandReadParties(Guid? id)
        //{
        //    if (id == null || id.Value == Guid.Empty)
        //        return false;

        //    if (IsAdministrator())
        //        return true;

        //    var partyService = new SGSReference.Services.PartyService();
        //    PartyDataSet.PartyRow party = partyService.GetParty(this.Operator(), id.Value).First();

        //    if (party.PartyTypeCode == "Laboratory")
        //        return true;
        //    else
        //        return false;
        //}

        //private bool CanDeleteAddress(Guid addressId)
        //{
        //    var partyService = new SGSReference.Services.PartyService();

        //    PartyDataSet.AddressDataTable addresses = partyService.GetAddress(this.Operator(), addressId);
        //    PartyDataSet.AddressRow address = addresses.First();
        //    return address.TypeCode != "REFERENCE";
        //}

        //private bool CanEditAddress(Guid addressId, string addressTypeCode)
        //{
        //    var partyService = new SGSReference.Services.PartyService();

        //    PartyDataSet.AddressDataTable addresses = partyService.GetAddress(this.Operator(), addressId);
        //    PartyDataSet.AddressRow address = addresses.First();
        //    if (address.TypeCode == "REFERENCE")
        //    {
        //        return addressTypeCode == address.TypeCode;
        //    }
        //    return addressTypeCode != "REFERENCE";
        //}

        //private bool CanEditLab(LabOperations.EditLab operation)
        //{
        //    if (operation != null && operation.LaboratoryId.HasValue && operation.LaboratoryId != Guid.Empty)
        //    {
        //        //#TFS WI#1576: Edit laboratory assignement
        //        string[] businesFunctions = { 
        //                                        "LAB", "BUSINESS", "CIProjectManager", 
        //                                        "QualityManager", "ITBusinessManager" ,"SafetyManager"
        //                                    };
        //        if (IsAssignedToLab(operation.LaboratoryId.Value, businesFunctions))
        //        {
        //            return HasPrivilege(operation.ToString());
        //        }
        //    }

        //    return false;
        //}

        ///// <summary>
        ///// Can Edit Capability : 
        ///// </summary>
        ///// <param name="operation"></param>
        ///// <returns></returns>
        //private bool CanEditCapability(LabOperations.EditCapability operation)
        //{
        //    if (operation != null && operation.LaboratoryId.HasValue && operation.LaboratoryId != Guid.Empty)
        //    {
        //        string[] businesFunctions = { "QualityManager" };
        //        if (IsAssignedToLab(operation.LaboratoryId.Value, businesFunctions))
        //        {
        //            return HasPrivilege(operation.ToString());
        //        }
        //    }

        //    return false;
        //}

        //private bool CanEditMeasure(LabOperations.EditMeasures operation)
        //{
        //    if (operation != null && operation.LaboratoryId.HasValue && operation.LaboratoryId != Guid.Empty)
        //    {
        //        string[] businesFunctions = { 
        //                                        "MEASURES", "BUSINESS", "CIProjectManager", 
        //                                        "QualityManager", "ITBusinessManager", 
        //                                        "ChiefOperatingOfficer", "RegionalManager", 
        //                                        "ManagingDirector", "ExecutiveVicePresident", 
        //                                        "VicePresident" 
        //                                    };
        //        if (IsAssignedToLab(operation.LaboratoryId.Value, businesFunctions))
        //        {
        //            return HasPrivilege(operation.ToString());
        //        }
        //    }

        //    return false;
        //}

        //private bool CanRunLabReports(LabOperations.RunLabReports operation)
        //{
        //    if (operation != null)
        //    {
        //        if (!operation.LaboratoryId.HasValue)
        //        {
        //            return HasPrivilege(operation.ToString());
        //        }
        //        else if (operation.LaboratoryId != Guid.Empty)
        //        {
        //            //#TFS WI #1577: Run laboratory report
        //            string[] businesFunctions = { 
        //                                          "MEASURES", "LAB", "BUSINESS", "CIProjectManager", 
        //                                          "QualityManager", "ITBusinessManager", 
        //                                          "ChiefOperatingOfficer", "RegionalManager", 
        //                                          "ManagingDirector", "ExecutiveVicePresident", 
        //                                          "VicePresident","SafetyManager"
        //                                        };
        //            if (IsAssignedToLab(operation.LaboratoryId.Value, businesFunctions))
        //            {
        //                return HasPrivilege(operation.ToString());
        //            }
        //        }
        //    }

        //    return false;
        //}

        ////WI 8707
        //private bool CanRunLabMeasuresReport(LabOperations.RunLabMeasuresReport operation)
        //{
        //    if (operation != null)
        //    {
        //        if (!operation.LaboratoryId.HasValue)
        //        {
        //            return HasPrivilege(operation.ToString());
        //        }
        //        else if (operation.LaboratoryId != Guid.Empty)
        //        {

        //            string[] roleWithAccessToAllLabs = { "ChiefOperatingOfficer", "ExecutiveVicePresident" };

        //            string[] businesFunctions = { 
        //                                          "MEASURES", "LAB", "BUSINESS", "CIProjectManager", 
        //                                          "QualityManager","ChiefOperatingOfficer", "RegionalManager", 
        //                                          "ExecutiveVicePresident", 
        //                                        };

        //            if (IsAssignedToLab(operation.LaboratoryId.Value, businesFunctions)
        //                || (this.Operator().Roles.Exists(a => roleWithAccessToAllLabs.Contains(a.Code))))
        //            {
        //                return HasPrivilege(operation.ToString());
        //            }

        //        }
        //    }

        //    return false;
        //}

        //private bool IsAssignedToLab(Guid laboratoryId)
        //{
        //    // The user is assigned or (s)he is an administrator
        //    return UserLaboratoryIdList.Exists(a => a.First == laboratoryId) || IsAdministrator();
        //}

        //private bool IsAssignedToLab(Guid laboratoryId, string[] businessFunctions)
        //{
        //    if (businessFunctions == null || businessFunctions.Length == 0)
        //        return IsAssignedToLab(laboratoryId);

        //    // The user is assigned to the lab with a specific business function or (s)he is an administrator
        //    return UserLaboratoryIdList.Exists(a => a.First == laboratoryId
        //                                                && businessFunctions.Contains(a.Second))
        //            || IsAdministrator();
        //}

        private bool IsAdministrator()
        {
            return new Operations.ManageReferencesSecurity().IsAuthorized();
        }

        private bool HasPrivilege(string operation)
        {
            return this.Operator().HasPrivilege(operation);
        }

        private bool HasPrivilege<T>(string operation, T facts)
        {
            return this.Operator().HasPrivilege<T>(operation, facts);
        }

        //private bool CanViewLabInstrument(LabOperations.ViewLabInstrument operation)
        //{
        //    // if user is admin always visible
        //    if (this.IsAdministrator())
        //        return true;

        //    if (operation != null && operation.LaboratoryId.HasValue && operation.LaboratoryId != Guid.Empty)
        //    {
        //        string[] businesFunctions = { 
        //                                        "LAB", "BUSINESS", "CIProjectManager", 
        //                                        "QualityManager", "ITBusinessManager" 
        //                                    };
        //        // if user is assign to lab, only visible for roles > public
        //        if (IsAssignedToLab(operation.LaboratoryId.Value, businesFunctions))
        //        {
        //            return HasPrivilege(operation.ToString());
        //        }
        //    }

        //    return false;
        //}

        //private bool CanEditDefaultTranslation(SGSReferenceOperations.UpdateReferenceDataDefaultTranslation operation)
        //{
        //    if (operation.ScopeCode != "Business")
        //        return false;

        //    var service = new SGSReference.Services.RefDataService();

        //    ReferenceDataViews.ReferenceDataDataTable refData = service.GetReferenceData(this.Operator(),
        //                                                                               operation.ReferenceTypeCode,
        //                                                                               operation.Code);
        //    if (refData == null || refData.Count == 0)
        //        return false;

        //    return !refData.First().IsSystem;
        //}

        #endregion
    }
}