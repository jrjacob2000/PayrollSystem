<%@ Page Title="Reference Management" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Payroll.Web.Pages.Administration.ReferenceManagement.Default" %>

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
                        <asp:GridView ID="gvDetails" Width="100%"  runat="server" AutoGenerateColumns="false"
                                OnRowEditing="gvDetails_RowEditing" OnRowDeleting="gvDetails_RowDeleting" OnRowDataBound="gvDetails_RowDataBound" DataKeyNames="Id"
                                EmptyDataText="No data available"  >
                              
                                <Columns>
                                    <asp:BoundField ItemStyle-Width="700px" DataField="Id" ItemStyle-CssClass="displayNone"
                                        HeaderStyle-CssClass="displayNone" HeaderText="Id" />
                                    <%--<asp:HyperLinkField DataTextField ="ReferenceTypeCode" HeaderText ="Reference Type" DataNavigateUrlFormatString="~/Pages/Administration/ReferenceManagement/view.aspx?id={0}"  DataNavigateUrlFields="id" />--%>
                                    <asp:BoundField ItemStyle-Width="800px" DataField="ReferenceValue" HeaderText="Description" />
                                    <asp:CommandField HeaderText="Action" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width ="100" ButtonType ="Image"  ShowEditButton="true" ShowDeleteButton ="true" />
                            
                                   <%-- <asp:TemplateField HeaderText = "Action">
                                        <ItemTemplate  >
                                            <asp:ImageButton ID="EditButton" runat="server" CssClass ="ui-icon ui-icon-pencil"
                                                CommandName="Edit" AlternateText="Edit" ToolTip="Edit" />
                                            <asp:ImageButton ID="DeleteButton" runat="server" ImageUrl="~/Resources/Images/delete.jpg"
                                                CommandName="Delete" OnClientClick="return confirm('Are you sure you want to delete this reference?');"
                                                AlternateText="Delete" ToolTip="Delete" />
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
                                </Columns>
                            </asp:GridView>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
       
    </div>
</asp:Content>
