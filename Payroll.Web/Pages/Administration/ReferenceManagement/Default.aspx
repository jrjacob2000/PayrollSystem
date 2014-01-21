<%@ Page Title="Reference Management" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Payroll.Web.Pages.Administration.ReferenceManagement.Default" %>

<%@ Register TagPrefix="uc" Namespace="Payroll.Web.Controls" Assembly="Payroll.Web" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script type="text/javascript">

        $(document).ready(
                $(function () {

                    $("#accordion").accordion();

                    $("#accordion").on("click", function () { });

                    $("#accordion").show().accordion({
                        autoHeight: false
                    });
                    $("#accordion div").css({ 'height': 'auto' });                    

                })

       );
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <button id="btnNewReference" runat="server" style="width: 140px" class="addButton">
            New Reference</button>
        <div id="accordion">
            <asp:Repeater ID="repAccordion" runat="server">
                <ItemTemplate>
                    <h3>
                        <%#Eval("Description")%></h3>
                    <div style=" height :200px">
                        <uc:ExtendedGridview ID="gvDetails" Width="100%"  runat="server" AutoGenerateColumns="false"
                                OnRowEditing="gvDetails_RowEditing" OnRowDeleting="gvDetails_RowDeleting"  DataKeyNames="Id"
                                EmptyDataText="No data available"  >
                                <Columns>
                                    
                                    <asp:BoundField ItemStyle-Width="700px" DataField="Id" ItemStyle-CssClass="displayNone"
                                        HeaderStyle-CssClass="displayNone" HeaderText="Id" />
                                    <%--<asp:HyperLinkField DataTextField ="ReferenceTypeCode" HeaderText ="Reference Type" DataNavigateUrlFormatString="~/Pages/Administration/ReferenceManagement/view.aspx?id={0}"  DataNavigateUrlFields="id" />--%>
                                    <asp:BoundField ItemStyle-Width="800px" DataField="ReferenceValue" HeaderText="Description" />
                                    <asp:CommandField HeaderText="Action" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width ="100" ButtonType ="Image"  ShowEditButton="true" ShowDeleteButton ="true" />
                            
                                </Columns>
                            </uc:ExtendedGridview>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
       
    </div>
</asp:Content>
