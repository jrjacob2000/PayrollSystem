<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AddressGrid.ascx.cs" Inherits="Payroll.Web.Pages.Employee.Address.AddressGrid" %>
<%@ Register TagPrefix="uc" Namespace="Payroll.Web.Controls" Assembly="Payroll.Web" %>
<div> 
        <uc:ExtendedGridview ID="grdAddress" Width ="100%" runat="server" DataKeyNames="Id" AutoGenerateColumns="false" EmptyDataText="No data available" >
            <Columns>
                <asp:BoundField HeaderText="Address" DataField="Address" />
                <asp:BoundField HeaderText="City/Mun" DataField="CityMun" />
                <asp:BoundField HeaderText="Prov/State" DataField="ProvState" />
                <asp:BoundField HeaderText="Zipcode" DataField="ZipCode" />
            </Columns>
        </uc:ExtendedGridview>
</div>
