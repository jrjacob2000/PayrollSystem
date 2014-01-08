<%@ Page Title="Reference Management" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Payroll.Web.Pages.Administration.ReferenceManagement.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript" src="../../../Scripts/jquery-1.7.1.min.js"></script>
    <script type="text/javascript">
        $("[src*=plus]").live("click", function () {
            $(this).closest("tr").after("<tr><td></td><td colspan = '999'>" + $(this).next().html() + "</td></tr>")
            $(this).attr("src", "../../../Resources/Images/minus.jpg");
        });
        $("[src*=minus]").live("click", function () {
            $(this).attr("src", "../../../Resources/Images/plus.jpg");
            $(this).closest("tr").next().remove();
        });
    </script>

    <div>
        <asp:LinkButton ID="lbCreate" runat="server">New Reference</asp:LinkButton>
        <asp:GridView ID="grdReference" Width="550px"   runat="server" AutoGenerateColumns="False" DataKeyNames ="ReferenceTypeCode" AllowCustomPaging="True" 
            OnRowDataBound ="grdReference_RowDataBound">
            <Columns>
                <asp:TemplateField ItemStyle-Width ="15px" >
                    <ItemTemplate>
                        <img alt = "" style="cursor: pointer" src="../../../Resources/Images/plus.jpg" />
                        <asp:Panel ID="pnlDetails" runat="server" Style="display: none">
                             <asp:GridView ID="gvDetails" Width="100%" runat="server" AutoGenerateColumns="false" OnRowEditing="gvDetails_RowEditing" OnRowDeleting="gvDetails_RowDeleting" DataKeyNames ="Id" EmptyDataText ="No data available">
                                 <Columns>                                    
                                     <asp:BoundField  ItemStyle-Width ="700px" DataField ="Id"  ItemStyle-CssClass="displayNone" HeaderStyle-CssClass="displayNone"  HeaderText ="Id"/>
                                    <%--<asp:HyperLinkField DataTextField ="ReferenceTypeCode" HeaderText ="Reference Type" DataNavigateUrlFormatString="~/Pages/Administration/ReferenceManagement/view.aspx?id={0}"  DataNavigateUrlFields="id" />--%>
                                    <asp:BoundField  ItemStyle-Width ="700px" DataField ="ReferenceValue" HeaderText ="Description"/>
                                    <asp:CommandField ItemStyle-Width ="30px"  DeleteText ="Delete" ShowDeleteButton ="true" ShowEditButton="true" HeaderText ="Action" />
                                     
                                 </Columns>
                              </asp:GridView>
                        </asp:Panel>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField ="Description"  ItemStyle-Width="100%" HeaderText ="Reference Type"/>
                                
            </Columns>            
        </asp:GridView>
    </div>
</asp:Content>
